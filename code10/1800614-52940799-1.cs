    using System.Collections.Immutable;
    using System.Composition;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CodeFixes;
    using Microsoft.CodeAnalysis.CodeActions;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using Microsoft.CodeAnalysis.Text;
    
    namespace AttributeAnalyzer
    {
        [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(AttributeAnalyzerCodeFixProvider)), Shared]
        public class AttributeAnalyzerCodeFixProvider : CodeFixProvider
        {
            public sealed override ImmutableArray<string> FixableDiagnosticIds
            {
                get { return ImmutableArray.Create(AttributeAnalyzerAnalyzer.DiagnosticId); }
            }
    
            public sealed override FixAllProvider GetFixAllProvider()
            {
                // See https://github.com/dotnet/roslyn/blob/master/docs/analyzers/FixAllProvider.md for more information on Fix All Providers
                return WellKnownFixAllProviders.BatchFixer;
            }
    
            public sealed override async Task RegisterCodeFixesAsync(CodeFixContext context)
            {
                Diagnostic diagnostic = context.Diagnostics.First();
                TextSpan diagnosticSpan = diagnostic.Location.SourceSpan;
    
                context.RegisterCodeFix(
                    CodeAction.Create(
                        title: "Remove attribute",
                        createChangedDocument: c => RemoveAttributeAsync(context.Document, diagnosticSpan, context.CancellationToken),
                        equivalenceKey: "Remove_Attribute"
                        ),
                    diagnostic
                    );            
            }
    
            private async Task<Document> RemoveAttributeAsync(Document document, TextSpan diagnosticSpan, CancellationToken cancellation)
            {
                SyntaxNode root = await document.GetSyntaxRootAsync(cancellation).ConfigureAwait(false);
                AttributeListSyntax attributeListDeclaration = root.FindNode(diagnosticSpan).FirstAncestorOrSelf<AttributeListSyntax>();
                SeparatedSyntaxList<AttributeSyntax> attributes = attributeListDeclaration.Attributes;
    
                if (attributes.Count > 1)
                {
                    AttributeSyntax targetAttribute = root.FindNode(diagnosticSpan).FirstAncestorOrSelf<AttributeSyntax>();
                    return document.WithSyntaxRoot(
                        root.RemoveNode(targetAttribute,
                        SyntaxRemoveOptions.KeepExteriorTrivia | SyntaxRemoveOptions.KeepEndOfLine | SyntaxRemoveOptions.KeepDirectives)
                        );
                }
                if (attributes.Count==1)
                {
                    return document.WithSyntaxRoot(
                        root.RemoveNode(attributeListDeclaration,
                        SyntaxRemoveOptions.KeepExteriorTrivia | SyntaxRemoveOptions.KeepEndOfLine | SyntaxRemoveOptions.KeepDirectives)
                        );
                }
                return document;
            }
        }
    }
