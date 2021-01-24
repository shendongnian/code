    public static class Functions
    {
        [WorkItemValidator]
        public static void ProcessWorkItem(
            [QueueTrigger("test")] WorkItem workItem)
        {
            Console.WriteLine($"Processed work item {workItem.ID}");
        }
    }
    
    public class WorkItemValidatorAttribute : FunctionInvocationFilterAttribute
    {
        public override Task OnExecutingAsync(
            FunctionExecutingContext executingContext, CancellationToken cancellationToken)
        {
            executingContext.Logger.LogInformation("WorkItemValidator executing...");
    
            var workItem = executingContext.Arguments.First().Value as WorkItem;
            string errorMessage = null;
            if (!TryValidateWorkItem(workItem, out errorMessage))
            {
                executingContext.Logger.LogError(errorMessage);
                throw new ValidationException(errorMessage);
            }
                    
            return base.OnExecutingAsync(executingContext, cancellationToken);
        }
    
        private static bool TryValidateWorkItem(WorkItem workItem, out string errorMessage)
        {
            // your validation logic goes here...
        }
    }
