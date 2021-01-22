    public class Test
    {
        public TClient MakeClient<TClient>()
            where TClient : ClientBase<IMyContract>, IMyContract, new()
        {
            return new TClient();
        }
    }
