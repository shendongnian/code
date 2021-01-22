    namespace XTrans.XferTableAdapters
    {
    
        public partial class FooTableAdapter
        {
            int? _timeout = null;
    
            ///<summary>
            ///Get or set the current timeout in seconds for Select statements.
            ///</summary>
            public int CurrentCommandTimeout
            {
                get
                {
                    int timeout = 0;
    
                    if (_timeout != null)
                    {
                        timeout = (int)_timeout;
                    }
                    else
                    {
                        for (int i = 0; i < this.CommandCollection.Length; i++)
                            if (this.CommandCollection[i] != null)
                                timeout = this.CommandCollection[i].CommandTimeout;
                    }
                    return timeout;
                }
    
                set
                {
                    if (this.CommandCollection == null)
                        this.InitCommandCollection();
    
                    for (int i = 0; i < this.CommandCollection.Length; i++)
                        if (this.CommandCollection[i] != null)
                        {
                            this.CommandCollection[i].CommandTimeout = value;
                            _timeout = value;
                        }
                }
    
            }
        }
    
    }
