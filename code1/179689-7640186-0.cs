    public static class OracleExtentions
    {
        public static void Dispose(this OracleDecimal od) // build an extension method
        {
            if (OracleDecimalOpoDecCtx == null)
            {
                // cache the data
                // get the underlying internal field info
                OracleDecimalOpoDecCtx = typeof(OracleDecimal).GetField("m_opoDecCtx", BindingFlags.Instance | BindingFlags.NonPublic);
            }
            IDisposable disposable = OracleDecimalOpoDecCtx.GetValue(od) as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
            }
        }
    
        private static FieldInfo OracleDecimalOpoDecCtx;
    }
