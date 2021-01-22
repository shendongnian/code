        [DebuggerNonUserCode]
        public static void CatchMany(Action tryBlock, Action<Exception> catchBlock,
            params Type[] exceptionTypes)
        {
            try
            {
                tryBlock();
            }
            catch (Exception exception)
            {
                if (exceptionTypes.Contains(exception.GetType())) catchBlock(exception);
                else throw;
            }
        }
