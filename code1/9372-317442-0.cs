    public virtual string ApplicationName
            {
                get 
                {
                    if (_applicationName == null) {  _applicationName = HttpRuntime.AppDomainAppId; }
                    return _applicationName;
                }
                set { _applicationName = value; }
            }
