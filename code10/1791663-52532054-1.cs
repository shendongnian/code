        public void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            // All unhandled exceptions will end up here, so do what you need here
            // For example log the error and etc...
            string tempMessage = e.Exception.Message;
            // log the error
            // show the error
            // shut the application down if needed
            // ROLLBACK database changes 
            // and so on...
        }
