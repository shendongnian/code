    public class DeviceProcessingResult<T> : DeviceProcessingResult<T, T>
    {
        public DeviceProcessingResult(IEnumerable<T> succeeded, IEnumerable<T> failed)
            : base(succeeded, failed)
        { /*Nothing more to do here...*/ }
    }
