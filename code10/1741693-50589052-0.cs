       public sealed override async Task RegisterCodeFixesAsync(CodeFixContext context)
        {
            var root = await context.Document.GetSyntaxRootAsync(context.CancellationToken).ConfigureAwait(false);
            var diagnostic = context.Diagnostics.First();
            var diagnosticSpan = diagnostic.Location.SourceSpan;
            // Find the type invocation expression identified by the diagnostic.
            var invocationExpr = root.FindToken(
                    diagnosticSpan.Start).Parent.AncestorsAndSelf()
                .OfType<InvocationExpressionSyntax>().First();
            // Get the symantec model from the document
            var semanticModel = await context.Document.GetSemanticModelAsync(context.CancellationToken).ConfigureAwait(false);
            // Check for the assembly we need.  I suspect there is a better way...
            var hasAssembly = semanticModel.Compilation.ExternalReferences.Any(er => er.Properties.Kind == MetadataImageKind.Assembly && er.Display.EndsWith("Trilogy.Common.dll"));
            // Register a code action that will invoke the fix, but only
            // if we have the assembly that we need
            if (hasAssembly)
                context.RegisterCodeFix(
                    CodeAction.Create(title, c => UseJoinAsync(
                        context.Document, invocationExpr, c), equivalenceKey: title), diagnostic);
        }
