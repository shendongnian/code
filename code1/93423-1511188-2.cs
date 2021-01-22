        /// <summary>
        /// Executes a method in a separate AppDomain.  This should serve as a simple replacement
        /// of running code in a separate process via a console app.
        /// </summary>
        public static T RunInAppDomain<T>(Func<T> func)
        {
            AppDomain domain = AppDomain.CreateDomain("Delegate Executor " + func.GetHashCode(), null,
                new AppDomainSetup { ApplicationBase = Environment.CurrentDirectory });
            try
            {
                domain.SetData("toInvoke", func);
                domain.DoCallBack(() => 
                { 
                    var f = AppDomain.CurrentDomain.GetData("toInvoke") as Func<T>;
                    AppDomain.CurrentDomain.SetData("result", f());
                });
                return (T)domain.GetData("result");
            }
            finally
            {
                AppDomain.Unload(domain);
            }
        }
        [Serializable]
        private class ActionDelegateWrapper
        {
            public Action Func;
            public int Invoke()
            {
                Func();
                return 0;
            }
        }
        public static void RunInAppDomain(Action func)
        {
            RunInAppDomain<int>( new ActionDelegateWrapper { Func = func }.Invoke );
        }
