    public class A
    {
        //TODO: Random(2) for debug only; Random() for real life
        readonly Random random = new Random(2);
        // Alphabet is a constant isn't it? 
        const string Alphabet = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        // read-only property; initial value is GenerateString(5)
        //TODO: You may want to capitalize the property - RandomString
        string randomString => GenerateString(5);
    
        public string GenerateString(int size)
        {
            // Validation
            if (size < 0)
              throw new ArgumentOutOfRangeException(nameof(size), "size must be non-negative");
            // Linq is often compact and readable
            return string.Concat(Enumerable
              .Range(0, size)
              .Select(i => Alphabet[random.Next(Alphabet.Length)]));
        }
    }
