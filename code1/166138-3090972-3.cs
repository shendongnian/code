    sealed class TelephoneNumber
    {
        // cannot create subclass of TelephoneNumber
    }
    class Address
    {
        public sealed string FormatAddress()
        {
            // this function cannot be overridden on a subclass
        }
    }
