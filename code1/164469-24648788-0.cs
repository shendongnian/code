    using System;
    using System.Security.Cryptography;
    public class SafeRandom : Random
    {
        private const int PoolSize = 2048;
        private static readonly Lazy<RandomNumberGenerator> Rng =
            new Lazy<RandomNumberGenerator>(() => new RNGCryptoServiceProvider());
        private static readonly Lazy<object> PositionLock =
            new Lazy<object>(() => new object());
        private static readonly Lazy<byte[]> Pool =
            new Lazy<byte[]>(() => GeneratePool(new byte[PoolSize]));
        private static int bufferPosition;
        public static int GetNext()
        {
            while (true)
            {
                var result = (int)GetRandomUInt32 & 0x7FFFFFFF;
                if (result != 0)
                {
                    return result;
                }
            }
        }
        public static int GetNext(int maxValue)
        {
            if (maxValue < 0)
            {
                throw new ArgumentException(
                    "Must be greater that or equal to zero.",
                    "maxValue");
                return GetNext(0, maxValue);
        }
        public static int GetNext(int minValue, int maxValue)
        {
            const long Max = 1 + (long)uint.MaxValue;
            if (minValue > maxValue)
            {
                throw new ArgumentException("minValue is greater than maxValue");
            }
            if (minValue == maxValue)
            {
                return minValue;
            }
            long diff = maxValue - minValue;
            var limit = Max - (Max % diff);
            while (true)
            {
                var rand = GetRandomUInt32();
                if (rand < limit)
                {
                    return (int)(minValue + (rand % diff));
                }
            }
        }
        public static void GetNextBytes(byte[] buffer)
        {
            if (buffer == null)
            {
                throw new ArgumentNullException("buffer");
            }
            if (buffer.Length < PoolSize)
            {
                lock (PositionLock.Value)
                {
                    if ((PoolSize - bufferPosition) < buffer.Length)
                    {
                        GeneratePool(Pool.Value);
                    }
                    Buffer.BlockCopy(
                        Pool.Value,
                        bufferPosition,
                        buffer,
                        0,
                        buffer.Length);
                    bufferPostion += buffer.Length;
                }
            }
            else
            {
                Rng.Value.GetBytes(buffer);
            }
        }
        public static double GetNextDouble()
        {
            return GetRandomUInt32() / (1.0 + uint.MaxValue);
        }
        public override int Next()
        {
            return GetNext();
        }
        public override int Next(int maxValue)
        {
            return GetNext(0, maxValue);
        }
        public override int Next(int minValue, int maxValue)
        {
            return GetNext(minValue, maxValue);
        }
        public override void NextBytes(byte[] buffer)
        {
            GetNextBytes(buffer);
        }
        public override double NextDouble()
        {
            return GetNextDouble();
        }
        private static byte[] GeneratePool(byte[] buffer)
        {
            bufferPosition = 0;
            Rng.Value.GetBytes(buffer);
            return buffer;
        }
        private static uint GetRandomUInt32()
        {
            uint result;
            lock (PositionLock.Value)
            {
                if ((PoolSize - bufferPosition) < sizeof(uint))
                {
                    GeneratePool(Pool.Value)
                }
                result = BitConvertor.ToUInt32(
                    Pool.Value,
                    bufferPosition);
                bufferPostion += sizeof(uint);
            }
            return result;
        }
    }
        
