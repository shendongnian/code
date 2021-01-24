    /// <summary>
    /// Defines the GPS coordinates model.
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public sealed class GpsCoordinatesModel
    {
        #region Properties
    
        /// <summary>
        /// Gets the latitude.
        /// </summary>
        [JsonProperty(PropertyName = "latitude", Required = Required.Always)]
        public double Latitude { get; }
    
        /// <summary>
        /// Gets the longitude.
        /// </summary>
        [JsonProperty(PropertyName = "longitude", Required = Required.Always)]
        public double Longitude { get; }
    
        #endregion
    
        #region Constructors
    
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if:
        /// - The Latitude is not within the interval [-90, 90].
        /// - The Longitude is not within the interval [-180, 180].
        /// </exception>
        [JsonConstructor]
        public GpsCoordinatesModel(double latitude, double longitude)
        {
            if (latitude < -90d || latitude > 90d)
                throw new ArgumentOutOfRangeException(nameof(latitude), latitude, $"The {nameof(latitude)} must be between -90 and 90.");
    
            if (longitude < -180d || longitude > 180d)
                throw new ArgumentOutOfRangeException(nameof(longitude), longitude, $"The {nameof(latitude)} must be between -180 and 180.");
    
            Latitude = latitude;
            Longitude = longitude;
        }
    
        #endregion
    }
