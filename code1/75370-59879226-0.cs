    protected global::System.Data.SqlClient.SqlCommand[] CommandCollection
        {
            get
            {
                if ((this._commandCollection == null))
                {
                    this.InitCommandCollection();
                    _commandCollection[0].CommandTimeout = 0;
                }
                _commandCollection[0].CommandTimeout = 0;
                return this._commandCollection;
            }
        }
