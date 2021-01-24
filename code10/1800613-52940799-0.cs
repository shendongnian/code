    using System;
    using System.Collections.Immutable;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.Diagnostics;
    
    namespace AttributeAnalyzer
    {
        [DiagnosticAnalyzer(LanguageNames.CSharp)]
        public class AttributeAnalyzerAnalyzer : DiagnosticAnalyzer
        {
            public const string DiagnosticId = "AttributeAnalyzer";
    
            private static DiagnosticDescriptor Rule = new DiagnosticDescriptor(
                    id: DiagnosticId,
                    title: "Magic cannot be constructed from Type",
                    messageFormat: "Magic cannot be built from Type '{0}'.",
                    category: "Design",
                    defaultSeverity: DiagnosticSeverity.Error,
                    isEnabledByDefault: true,
                    description: "The IsMagic attribue needs to be attached to Types that can be rendered as Magic."
                    );
            public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get { return ImmutableArray.Create(Rule); } }
    
            public override void Initialize(AnalysisContext context)
            {
                context.RegisterSyntaxNodeAction(
                    AnalyzeSyntax,
                    SyntaxKind.PropertyDeclaration, SyntaxKind.FieldDeclaration
                    );
            }
    
            private static void AnalyzeSyntax(SyntaxNodeAnalysisContext context)
            {
                ITypeSymbol memberTypeSymbol = null;
                if (context.ContainingSymbol is IPropertySymbol)
                {
                    memberTypeSymbol = (context.ContainingSymbol as IPropertySymbol)?.GetMethod?.ReturnType;
                }
                else if (context.ContainingSymbol is IFieldSymbol)
                {
                    memberTypeSymbol = (context.ContainingSymbol as IFieldSymbol)?.Type;
                }
                else throw new InvalidOperationException("Can only analyze property and field declarations.");
    
                // Check if this property of field is decorated with the IsMagic attribute
                INamedTypeSymbol isMagicAttribute = context.SemanticModel.Compilation.GetTypeByMetadataName("MagicTest.IsMagic");
                ISymbol thisSymbol = context.ContainingSymbol;
                ImmutableArray<AttributeData> attributes = thisSymbol.GetAttributes();
                bool hasMagic = false;
                Location attributeLocation = null;
                foreach (AttributeData attribute in attributes)
                {
                    if (attribute.AttributeClass != isMagicAttribute) continue;
                    hasMagic = true;
                    attributeLocation = attribute.ApplicationSyntaxReference.SyntaxTree.GetLocation(attribute.ApplicationSyntaxReference.Span);
                    break;
                }
                if (!hasMagic) return;
    
                // Check if we can make Magic using the current property or field type
                if (!CanMakeMagic(context,memberTypeSymbol))
                {
                    var diagnostic = Diagnostic.Create(Rule, attributeLocation, memberTypeSymbol.Name);
                    context.ReportDiagnostic(diagnostic);
                }
                
            }
    
            /// <summary>
            /// Check if a given type can be wrapped in Magic in the current context.
            /// </summary>
            /// <param name="context"></param>
            /// <param name="sourceTypeSymbol"></param>
            /// <returns></returns>
            private static bool CanMakeMagic(SyntaxNodeAnalysisContext context, ITypeSymbol sourceTypeSymbol)
            {
                INamedTypeSymbol magic = context.SemanticModel.Compilation.GetTypeByMetadataName("MagicTest.Magic");
                ImmutableArray<IMethodSymbol> constructors = magic.Constructors;
    
                foreach (IMethodSymbol methodSymbol in constructors)
                {
                    ImmutableArray<IParameterSymbol> parameters = methodSymbol.Parameters;
                    IParameterSymbol param = parameters[0]; // All Magic constructors take one parameter
                    ITypeSymbol paramType = param.Type;
    
                    Conversion conversion = context.Compilation.ClassifyConversion(sourceTypeSymbol, paramType);
                    if (conversion.Exists && conversion.IsImplicit) return true; // We've found at least one way to make Magic
                }
    
                return false;
            }
        }
    }
