    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public sealed class TooManyReferencesAnalyzer : DiagnosticAnalyzer
    {
        private static DiagnosticDescriptor TooManyReferences { get; } =
            new DiagnosticDescriptor(
                "DEMO",
                "Don't use too many references",
                "The project '{0}' has {1} references",
                category: "Maintainability",
                defaultSeverity: DiagnosticSeverity.Warning,
                isEnabledByDefault: true);
        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics =>
            ImmutableArray.Create(TooManyReferences);
        public override void Initialize(AnalysisContext context)
        {
            context.RegisterCompilationAction(AnalyzeCompilation);
        }
        private void AnalyzeCompilation(CompilationAnalysisContext context)
        {
            var compilation = context.Compilation;
            int referenceCount = compilation.References.Count();
            if (referenceCount > 5)
            {
                context.ReportDiagnostic(
                    Diagnostic.Create(
                        TooManyReferences,
                        null,
                        compilation.AssemblyName,
                        referenceCount));
            }
        }
    }
