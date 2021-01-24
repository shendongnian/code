    [StructLayout(LayoutKind.Auto)]
    [CompilerGenerated]
    private struct <Contains>d__0 : IAsyncStateMachine
    {
        public int <>1__state;
        public AsyncTaskMethodBuilder<bool> <>t__builder;
        private void MoveNext()
        {
            bool result;
            try
            {
                result = false;
            }
            catch (Exception exception)
            {
                <>1__state = -2;
                <>t__builder.SetException(exception);
                return;
            }
            <>1__state = -2;
            <>t__builder.SetResult(result);
        }
        void IAsyncStateMachine.MoveNext()
        {
            //ILSpy generated this explicit interface implementation from .override directive in MoveNext
            this.MoveNext();
        }
        [DebuggerHidden]
        private void SetStateMachine(IAsyncStateMachine stateMachine)
        {
            <>t__builder.SetStateMachine(stateMachine);
        }
        void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
        {
            //ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
            this.SetStateMachine(stateMachine);
        }
    }
    [AsyncStateMachine(typeof(<Contains>d__0))]
    public Task<bool> Contains(string key, string scope)
    {
        <Contains>d__0 stateMachine = default(<Contains>d__0);
        stateMachine.<>t__builder = AsyncTaskMethodBuilder<bool>.Create();
        stateMachine.<>1__state = -1;
        AsyncTaskMethodBuilder<bool> <>t__builder = stateMachine.<>t__builder;
        <>t__builder.Start(ref stateMachine);
        return stateMachine.<>t__builder.Task;
    }
