        private readonly TcpConnectionManager _tcpManager = new TcpConnectionManager();
        public string _query;
        
        public void SaveQuery(string query)
        {
            _query = query;
        }
        public HotelList ReturnQuery()
        {
            HotelList hotelList = _tcpManager.ReturnHotelList(_query);
            return hotelList;
        }
