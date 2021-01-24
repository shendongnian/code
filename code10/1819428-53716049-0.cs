        string _cityName;
        string _governate;
        int _countryId;
        private string cityName { get; set; }
        private string governate { get; set; }
        private int countryId { get; set; }
        public void prepare()
        {
            _cityName = cityName;
            _governate = governate;
            _countryId = countryId;
        }
        public  void insertCity( string _cityName ,string _governate, int _countryId)
        {
            try
            {
                    _socket = new _ctrlChannel();
                
                    MySqlParameter[] zair = new MySqlParameter[4];
                    zair[0] = new MySqlParameter("@cityNamee", MySqlDbType.VarChar, 45)
                    { Value = _cityName, Direction = ParameterDirection.Input
                    };
                    zair[1] = new MySqlParameter("@bGovernate", MySqlDbType.VarChar)
                    { Value = _governate, Direction = ParameterDirection.Input
                    };
                    zair[2] = new MySqlParameter("@cconId", MySqlDbType.VarChar)
                    { Value = _countryId, Direction = ParameterDirection.Input
                    };
                    zair[3] = new MySqlParameter("@ccityId", MySqlDbType.Int32,5)
                    {  Direction = ParameterDirection.Output,Value=DBNull.Value
                    };
                
                _socket.connect();
                _socket.Transfare("addCity", zair);
                _socket.disConnect();
            }
            catch (MySql.Data.MySqlClient.MySqlException we) { MessageBox.Show("error" + we); }
        }
    
