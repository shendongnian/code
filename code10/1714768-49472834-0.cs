    [Serializable()]
    public struct Convertor 
    {
        public string License { get; set; }
        public int Software { get; set; }
        public int StartDate { get; set; }
        public int EndDate { get; set; }
        public byte Count { get; set; }
        public int[] ActionCode { get; set; }
        public byte[] ConvertToArray()
        {
            var bf = new BinaryFormatter();
            using (var mem = new MemoryStream())
            {
                bf.Serialize(mem, this);
                return mem.ToArray();
            }
        }
        public static Convertor ConvertFromArray(byte[] buffer)
        {
            var bf = new BinaryFormatter();
            using (var mem = new MemoryStream(buffer))
            {
                return (Convertor)bf.Deserialize(mem);
            }
        }
        /// <summary>
        /// Checks for equality among <see cref="Convertor"/> classes
        /// </summary>
        /// <param name="other">The other <see cref="Convertor"/> to compare it to</param>
        /// <returns>True if equal</returns>
        public bool Equals(Convertor other)
        {
            return License == other.License
                && Software == other.Software
                && StartDate == other.StartDate
                && EndDate == other.EndDate
                && Count == other.Count
                && ActionCode.SequenceEqual(other.ActionCode);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new object and add some data to it
            var a = new Convertor()
            {
                License = "ABC001",
                Software = 1,
                StartDate = 2018,
                EndDate = 2019,
                Count = 16,
                ActionCode = new[] { 67, 79, 68, 69, 49, 50, 51 }
            };
            // Serialize the object into a byte array
            var buffer = a.ConvertToArray();
            // Deserialize a new object from the byte array
            var b = Convertor.ConvertFromArray(buffer);
            // Check for equality
            var ok = a.Equals(b); // ok = true
        }
    }
