            try
            {
                ProcessHandler handler = new ProcessHandler(DoTaskForTry, DoTaskForCatch, DoTaskForFinally);
                handler.InvokeActions();
            }
            catch (Exception exception)
            {
                var processError = exception as ProcessHandler;
                /*this exception contains all exceptions*/
                throw new Exception("Error to Process Actions", exception);
            }
