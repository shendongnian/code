    internal class NavigateAfterCodeChangeAction : CodeAction
    {
      private readonly Func<CancellationToken, Task<Solution>> codeChangeOperation;
      private readonly Func<Solution, CancellationToken, Task<NavigationTarget>> navigationTargetCalculation;
      public NavigateAfterCodeChangeAction(
        string title,
        Func<CancellationToken, Task<Solution>> codeChangeOperation,
        Func<Solution, CancellationToken, Task<NavigationTarget>> navigationTargetCalculation)
      {
        this.Title = title;
        this.codeChangeOperation = codeChangeOperation;
        this.navigationTargetCalculation = navigationTargetCalculation;
      }
      public override string Title { get; }
      protected override async Task<IEnumerable<CodeActionOperation>> ComputeOperationsAsync(CancellationToken cancellationToken)
      {
        var operations = new List<CodeActionOperation>();
        Solution changedSolution = await this.codeChangeOperation(cancellationToken);
        NavigationTarget navigationTarget = await this.navigationTargetCalculation(changedSolution, cancellationToken);
        operations.Add(new ApplyChangesOperation(changedSolution));
        if (navigationTarget != null)
        {
          operations.Add(new DocumentNavigationOperation(navigationTarget.DocumentId, navigationTarget.Position));
        }
        return operations;
      }
    }
    internal class NavigationTarget
    {
    
      public NavigationTarget(DocumentId documentId, int position)
      {
        this.DocumentId = documentId;
        this.Position = position;
      }
      public DocumentId DocumentId { get; }
      public int Position { get; }
    }
