        public ICommand HandleErrorCommand
        {
            get
            {
                if (_handleErrorCommand == null)
                    _handleErrorCommand = new RelayCommand<object>(param => OnDisplayError(param));
                return _handleErrorCommand;
            }
        }
        private void OnDisplayError(object param)
        {
            string message = "Error!";
            var errorArgs = param as ValidationErrorEventArgs;
            if (errorArgs != null)
            {
                var exception = errorArgs.Error.Exception;
                while (exception != null)
                {
                    message = exception.Message;
                    exception = exception.InnerException;
                }
            }
            Status = message;
        }
