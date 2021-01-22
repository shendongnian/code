    public sealed class GetWorkflowIdActivity : CodeActivity<string>
    {
        protected override string Execute(CodeActivityContext context)
        {
            return context.WorkflowInstanceId.ToString();
        }
    }
