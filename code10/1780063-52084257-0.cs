    public interface IClipbaseData<T>
    {
        T ClipObjectData { get; set; }
    }
    class ClipTextData : IClipbaseData<string>
    {
        string _clipContent;
        public string ClipObjectData
        {
            get
            {
                return _clipContent;
            }
            set
            {
                // validate the input
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Error");
                }
                _clipContent = value;
            }
        }
    }
