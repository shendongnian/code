    GeoJsonPoint<GeoJson2DGeographicCoordinates> _location;
        [BsonElement("Location")]
        public GeoJsonPoint<GeoJson2DGeographicCoordinates> Location
        {
            get => _location;
            set
            {
                if (_location == value)
                    return;
                _location = value;
                HandlePropertyChanged();
            }
        }
