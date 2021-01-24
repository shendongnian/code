        public class DeviceProcessingResult<TFailed> : DeviceProcessingResult< DeviceResponse, TFailed>
        {
            public DeviceProcessingResult(IEnumerable<DeviceResponse> succeeded, IEnumerable<TFailed> failed) : base(succeeded, failed)
            {
            }
        }
