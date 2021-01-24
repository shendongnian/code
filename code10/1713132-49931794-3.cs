        private void EnsureTheConnectionMultiplexerIsSet()
        {
            if (_connection != null) return;
            cche.Get("startup"); //populate the connection with a dummy request
            var _connectionMultiplexorFieldInfo = typeof(RedisCache).GetField(nameof(_connection), BindingFlags.NonPublic | BindingFlags.Instance);
            var vl = _connectionMultiplexorFieldInfo.GetValue(cche);
            if (vl != null)
            {
                _connection = (ConnectionMultiplexer)vl;
                if (_connection == null) throw new InvalidCastException("Could not cast the ConnectionMultiplexer");
            }
            if (_connection == null) throw new InvalidCastException("Could not access the ConnectionMultiplexer");
        }
