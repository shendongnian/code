        private static void OverrideTransactionScopeMaximumTimeout(TimeSpan timeOut)
        {
            // 1. create a object of the type specified by the fully qualified name
            Type oSystemType = typeof(global::System.Transactions.TransactionManager);
            System.Reflection.FieldInfo oCachedMaxTimeout = oSystemType.GetField("_cachedMaxTimeout", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
            System.Reflection.FieldInfo oMaximumTimeout = oSystemType.GetField("_maximumTimeout", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
            oCachedMaxTimeout.SetValue(null, true);
            oMaximumTimeout.SetValue(null, timeOut);
            // For testing to confirm value was changed
            // MessageBox.Show(string.Format(&quot;DEBUG SUCCESS!! &nbsp;Maximum Timeout for transactions is &#39;{0}&#39;&quot;, TransactionManager.MaximumTimeout.ToString()));
        }
