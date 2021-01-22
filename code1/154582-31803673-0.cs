    public class CloseAppResult : CancelResult
    {
        public override void Execute(CoroutineExecutionContext context)
        {
            Application.Current.Shutdown();
            base.Execute(context);
        }
    }
    public class CancelResult : Result
    {
        public override void Execute(CoroutineExecutionContext context)
        {
            OnCompleted(this, new ResultCompletionEventArgs { WasCancelled = true });
        }
    }
