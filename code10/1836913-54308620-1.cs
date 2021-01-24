    public class DeviceProcessingResult<T> : DeviceProcessingResult<T, T>
    {
        public DeviceProcessingResult(IEnumerable<T> succeeded, IEnumerable<T> failed)
            : base(succeeded, failed)
        { /*Nothing more to do here...*/ }
    }
    public class DeviceProcessingResult<T, T1>
    {
        public T[] Succeeded { get; set; }
        public T1[] Failed { get; set; }
        public DeviceProcessingResult(IEnumerable<T> succeeded, IEnumerable<T1> failed)
        {
            Succeeded = succeeded.ToArray();
            Failed = failed.ToArray();
        }
    }
