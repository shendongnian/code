        static IEnumerable<int> Random(RandomNumberGenerator rng, int min, int max)
        {
            var buffer = new byte[4096];
            while (true)
            {
                rng.GetBytes(buffer);
                for (var i = 0; i < buffer.Length / 4; i += 4)
                {
                    var value = BitConverter.ToUInt32(buffer, i);
                    var normalizedValue = value / (double)uint.MaxValue;
                    yield return (int)(normalizedValue * (max - min)) + min;
                }
            }
        }
