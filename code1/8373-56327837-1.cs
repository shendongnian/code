        [DebuggerNonUserCode]
        public static void Catch<TException1, TException2>(Action tryBlock,
            Action<Exception> catchBlock)
        {
            CatchMany(tryBlock, catchBlock, typeof(TException1), typeof(TException2));
        }
        [DebuggerNonUserCode]
        public static void Catch<TException1, TException2, TException3>(Action tryBlock,
            Action<Exception> catchBlock)
        {
            CatchMany(tryBlock, catchBlock, typeof(TException1), typeof(TException2), typeof(TException3));
        }
