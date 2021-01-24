    private static string _Id;
    public static string Id
    {
        get => _Id;
        set // You want to use value here (new value), not Id (old value)
        {
            if (value == null)
            {
                // Consider what you want to do if user calls Id = null
                _Id = new string('0', Idlen);
            }
            else if (value.Length < Idlen)
            {
                var zero = new string('0', Idlen - value.Length);
                _Id = zero + value;
            }
            else
            {
                _Id = value.Substring(value.Length - Idlen);
            }
        }
    }
    public static int Idlen { get; set; }
