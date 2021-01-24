    public class RandomGenerator
    {
        private readonly RandomNumberGenerator _rng;
        
        public RandomGenerator(RandomNumberGenerator rng)
        {
            _rng = rng;
        }
        public IEnumerable<int> Next(ulong range)
        {
            var buffer = new byte[8 * 512];
            var bits = (int) Math.Ceiling(Math.Log(range) / Math.Log(2));
            var mask = (ulong) ~(~0 << bits);
            while (true)
            {
                _rng.GetBytes(buffer);
                for (var i = 0; i < buffer.Length / 8; i += 8)
                {
                    var num = BitConverter.ToUInt64(buffer, i);
                    var n = num & mask;
                    if (n <= range - 1)
                    {
                        yield return (int) n;
                    }
                }
            }
        }
        public IEnumerable<int> Next(int min, int max)
        {
            if (min > max) throw new ArgumentOutOfRangeException(nameof(min));
            var range = (ulong) Math.Abs(max - min);
            return Random(range).Select(r => r + min);
        }
    }
