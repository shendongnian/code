    List<SomeTableEntity> result = DatabaseHelpers.ExecuteRetryable<List<SomeTableEntity>>(() =>
        {           
            using (EfCtx ctx = new EfCtx())
            {
                return ctx.SomeTable.Where(...).ToList()
            }
        }, out int actualAttempts, allowRetryOnTimeout: true);
