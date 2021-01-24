        public static class AsyncCommand
        {
            public static AsyncCommand<object> Create(Func<Task> command)
            {
                return new AsyncCommand<object>(async () => { await command(); return null; });
            }
    
            public static AsyncCommand<TResult> Create<TResult>(Func<Task<TResult>> command)
            {
                return new AsyncCommand<TResult>(command);
            }
        }
