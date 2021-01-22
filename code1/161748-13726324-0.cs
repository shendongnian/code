        private void YourMethod()
        {
            if (Application.Current.Dispatcher.CheckAccess())
            {
                // do whatever you want to do with shared object.
            }
            else
            {
                //Other wise re-invoke the method with UI thread access
                Application.Current.Dispatcher.Invoke(new System.Action(() => YourMethod()));
            }
        }
