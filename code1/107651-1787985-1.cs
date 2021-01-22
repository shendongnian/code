    public class Travel : IDataErrorInfo
    {
        public int MinAirportArrival { get; set; }
        public int MinFlightTime { get; set; }
        public int TotalTravelTime { get; set; }
        string IDataErrorInfo.this[string property] {
            get {
                switch (property) {
                    case "TotalTravelTime":
                        if (TotalTravelTime < MinAirportArrival + MinFlightTime) {
                            return "not enough time blah";
                        }
                        break;
                }
                return "";
            }
        }
        string IDataErrorInfo.Error {
            get {
                StringBuilder sb = new StringBuilder();
                AppendError(ref sb, "MinAirportArrival");
                AppendError(ref sb, "MinFlightTime");
                AppendError(ref sb, "TotalTravelTime");
                return sb == null ? "" : sb.ToString();
            }
        }
        void AppendError(ref StringBuilder builder, string propertyName) {
            string error = ((IDataErrorInfo)this)[propertyName];
            if (!string.IsNullOrEmpty(error)) {
                if (builder == null) {
                    builder = new StringBuilder(error);
                } else {
                    builder.Append(error);
                }
            }
        }
    }
