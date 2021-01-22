        private void InitCommandCollection() {
            this._commandCollection = new global::System.Data.SqlClient.SqlCommand[1];
            this._commandCollection[0] = new global::System.Data.SqlClient.SqlCommand();
            this._commandCollection[0].Connection = this.Connection;
            this._commandCollection[0].CommandText = @"SELECT * FROM MyTable WHERE ID >50;";
            this._commandCollection[0].CommandType = global::System.Data.CommandType.Text;
        }
