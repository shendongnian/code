        private ErrorProvider _ErrorProvider = null;
        //PropertyOnDemand
        private ErrorProvider ErrorProviders
        {
            get
            {
                if (_ErrorProvider == null)
                {
                    _ErrorProvider = new ErrorProvider();
                    return _ErrorProvider;
                }
                else
                    return _ErrorProvider;
            }
        }
        public bool IsFieldEmpty(ref TextBox txtControl, Boolean SetErrorProvider, string msgToShowOnError)
        {
            if (txtControl.Text == string.Empty)
            {
                if (SetErrorProvider == true)
                    ErrorProviders.SetError(txtControl, msgToShowOnError);
                return true;
            }
            else
            {
                if (SetErrorProvider == true)
                    ErrorProviders.Clear();
                return false;
            }
        }
