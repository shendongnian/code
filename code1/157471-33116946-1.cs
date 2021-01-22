        /// <summary>
        /// DateTime as UTV for UnixEpoch
        /// </summary>
        public static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        /// <summary>
        /// Per JWT spec:
        /// Gets the number of seconds from 1970-01-01T0:0:0Z as measured in UTC until the desired date/time.
        /// </summary>
        /// <param name="datetime">The DateTime to convert to seconds.</param>
        /// <remarks>if dateTimeUtc less than UnixEpoch, return 0</remarks>
        /// <returns>the number of seconds since Unix Epoch.</returns>
        public static long GetIntDate(DateTime datetime)
        {
            DateTime dateTimeUtc = datetime;
            if (datetime.Kind != DateTimeKind.Utc)
            {
                dateTimeUtc = datetime.ToUniversalTime();
            }
            if (dateTimeUtc.ToUniversalTime() <= UnixEpoch)
            {
                return 0;
            }
            return (long)(dateTimeUtc - UnixEpoch).TotalSeconds;
        }    
