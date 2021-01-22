        public static void Handle<T>(Action action, Action<T> handler)
            where T : Exception
        {
            try
            {
                action();
            }
            catch (T exception)
            {
                handler(exception);
            }
        }
        public static void Handle<T1, T2>(Action action, Action<Exception> handler)
            where T1 : Exception
            where T2 : Exception
        {
            try
            {
                action();
            }
            catch (T1 exception)
            {
                handler(exception);
            }
            catch (T2 exception)
            {
                handler(exception);
            }
        }
        public static void Handle<T1, T2, T3>(Action action, Action<Exception> handler)
            where T1 : Exception
            where T2 : Exception
            where T3 : Exception
        {
            try
            {
                action();
            }
            catch (T1 exception)
            {
                handler(exception);
            }
            catch (T2 exception)
            {
                handler(exception);
            }
            catch (T3 exception)
            {
                handler(exception);
            }
        }
        public static void Handle<T1, T2, T3, T4>(Action action, Action<Exception> handler)
            where T1 : Exception
            where T2 : Exception
            where T3 : Exception
            where T4 : Exception
        {
            try
            {
                action();
            }
            catch (T1 exception)
            {
                handler(exception);
            }
            catch (T2 exception)
            {
                handler(exception);
            }
            catch (T3 exception)
            {
                handler(exception);
            }
            catch (T4 exception)
            {
                handler(exception);
            }
        }
    }
    public class Example
    {
        public void LoadControl()
        {
            Exceptions.Handle<FileNotFoundException, ArgumentNullException, NullReferenceException>(() => LoadControlCore(10), GenericExceptionHandler);   
        }
        private void LoadControlCore(int myArguments)
        {
            //execute method as normal
        }
        public void GenericExceptionHandler(Exception e)
        {
            //do something
            Debug.WriteLine(e.Message);
        }        
    }
