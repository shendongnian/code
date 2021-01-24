    public class MyCodeFixProvider : CodeFixProvider
    {
      ...
      public async override Task RegisterCodeFixesAsync(CodeFixContext context)
      {
        await Task.Run(() =>
          {
            Diagnostics diagnostics = context.Diagnostics.First();
            CodeAction codeFix = new NavigateAfterCodeChangeAction(
              "Title",
              c => CreateXmlDocs(...)
              (s, c) => CalculateNavigationTarget(context.Document));
            context.RegisterCodeFix(codeFix, diagnostics);
          }
        ).ConfigureAwait(false);
      }
      private static NavigationTarget CalculateNavigationTarget(Document doc)
      {
        // Calculate the navigation target here...
        // Example: Navigate to position 42 of the document
        return new NavigationTarget(doc.Id, 42);
      }
      ...
    }
