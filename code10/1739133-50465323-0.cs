    [AsyncStateMachine(typeof(<AwaitedAsync>d__1))]
    private Task<string> AwaitedAsync(int x)
    {
        <AwaitedAsync>d__1 <AwaitedAsync>d__ = default(<AwaitedAsync>d__1);
        <AwaitedAsync>d__.<>4__this = this;
        <AwaitedAsync>d__.x = x;
        <AwaitedAsync>d__.<>t__builder = AsyncTaskMethodBuilder<string>.Create();
        <AwaitedAsync>d__.<>1__state = -1;
        AsyncTaskMethodBuilder<string> <>t__builder = <AwaitedAsync>d__.<>t__builder;
        <>t__builder.Start(ref <AwaitedAsync>d__);
        return <AwaitedAsync>d__.<>t__builder.Task;
    }
    [StructLayout(LayoutKind.Auto)]
    [CompilerGenerated]
    private struct <AwaitedAsync>d__1 : IAsyncStateMachine
    {
        public int <>1__state;
        public AsyncTaskMethodBuilder<string> <>t__builder;
        public C <>4__this;
        public int x;
        private TaskAwaiter<string> <>u__1;
        private void MoveNext()
        {
            int num = <>1__state;
            C c = <>4__this;
            string result;
            try
            {
                TaskAwaiter<string> awaiter;
                if (num != 0)
                {
                    awaiter = c.DoSomethingPrettyAsync(x).GetAwaiter();
                    if (!awaiter.IsCompleted)
                    {
                        num = (<>1__state = 0);
                        <>u__1 = awaiter;
                        <>t__builder.AwaitUnsafeOnCompleted(ref awaiter, ref this);
                        return;
                    }
                }
                else
                {
                    awaiter = <>u__1;
                    <>u__1 = default(TaskAwaiter<string>);
                    num = (<>1__state = -1);
                }
                result = awaiter.GetResult();
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
