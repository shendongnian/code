        // This property is connected to the window using databinding
        public string ExceptionThrowingBoundedField
        {
            get
            {
                try
                {
                    // This function might throw an exception
                    return GetValueFromDatabase();               
                }
                catch (Exception ex)
                {
                    ApplicationException exWrapper = new ApplicationException(
                        "Wrapped Exception",                                                     
                         ex
                    );
                    Action throwException = () => { throw exWrapper; };
                    Dispatcher.CurrentDispatcher.BeginInvoke(throwException);
                    return "";
                }
            }
        }
