    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Text;
    using System.Threading;
    public static class ArrayExtentions
    {
        public static object[] Shuffle(this object[] array)
        {
            var alreadySwaped = new HashSet<Tuple<int, int>>();
            var rndLoopCount = RandomUtils.GetRandom(Convert.ToInt32(array.Length / 4), Convert.ToInt32((array.Length / 2) + 1));
            for (var i = 0; i <= rndLoopCount; i++)
            {
                int rndIndex1 = 0, rndIndex2 = 0;
                do
                {
                    rndIndex1 = RandomUtils.GetRandom(0, array.Length);
                    rndIndex2 = RandomUtils.GetRandom(0, array.Length);
                } while (alreadySwaped.Contains(new Tuple<int, int>(rndIndex1, rndIndex2)));
                alreadySwaped.Add(new Tuple<int, int>(rndIndex1, rndIndex2));
                var swappingItem = array[rndIndex1];
                array[rndIndex1] = array[rndIndex2];
                array[rndIndex2] = swappingItem;
            }
            return array;
        }
    }
    public class RandomUtils
    {
        private static readonly ThreadLocal<Random> RndLocal = new ThreadLocal<Random>(() => new Random(GetUniqueSeed()));
        private static int GetUniqueSeed()
        {
            long next, current;
            var guid = Guid.NewGuid().ToByteArray();
            var seed = BitConverter.ToInt64(guid, 0);
            do
            {
                current = Interlocked.Read(ref seed);
                next = current * BitConverter.ToInt64(guid, 3);
            } while (Interlocked.CompareExchange(ref seed, next, current) != current);
            return (int)next ^ Environment.TickCount;
        }
        public static int GetRandom(int min, int max)
        {
            Contract.Assert(max >= min);
            return RndLocal.Value.Next(min, max);
        }
        public static int GetRandom(int max)
        {
            return RndLocal.Value.Next(max);
        }
        public static double GetRandom()
        {
            return RndLocal.Value.NextDouble();
        }
    }
    public class StringUtility
    {
        private const string UpperAlpha = "ABCDEFGHIJKLMNOPQRSTUWXYZ";
        private const string LowerAlpha = "abcdefghijklmnopqrstuwxyz";
        private const string Numbers = "0123456789";
        private const string SpecialChars = "~!@#$%^&*()_-+=.?";
        private static string CreateSourceString(bool includeLowerCase, bool includeUpperCase, bool includenumbers, bool includeSpChars)
        {
            Contract.Assert(includeLowerCase || includeUpperCase || includenumbers || includeSpChars);
            var sb = new StringBuilder();
            if (includeLowerCase) sb.Append(LowerAlpha);
            if (includeUpperCase) sb.Append(UpperAlpha);
            if (includenumbers) sb.Append(Numbers);
            if (includeSpChars) sb.Append(SpecialChars);
            return sb.ToString();
        }
        private static string GenerateString(string sourceString, int length = 6)
        {
            var rndString = Shuffle(sourceString);
            var builder = new StringBuilder();
            for (var i = 0; i < length; i++)
                builder.Append(rndString[RandomUtils.GetRandom(0, rndString.Length)]);
            return builder.ToString();
        }
        public static string GenerateRandomString(int length = 6,
            bool includenumbers = false,
            bool includeSpChars = false)
        {
            var sourceStr = CreateSourceString(true, true, includenumbers, includeSpChars);
            return GenerateString(sourceStr, length);
        }
        public static string GenerateRandomString(int minLength,
            int maxLength,
            bool includenumbers = false,
            bool includeSpChars = false)
        {
            if (maxLength < minLength) maxLength = minLength;
            var len = RandomUtils.GetRandom(minLength, maxLength + 1);
            return GenerateRandomString(len, includenumbers, includeSpChars);
        }
        public static string Shuffle(string str)
        {
            var alreadySwaped = new HashSet<Tuple<int, int>>();
            var rndLoopCount = RandomUtils.GetRandom(Convert.ToInt32(str.Length / 4), Convert.ToInt32((str.Length / 2) + 1));
            var strArray = str.ToArray();
            for (var i = 0; i <= rndLoopCount; i++)
            {
                int rndIndex1 = 0, rndIndex2 = 0;
                do
                {
                    rndIndex1 = RandomUtils.GetRandom(0, str.Length);
                    rndIndex2 = RandomUtils.GetRandom(0, str.Length);
                } while (alreadySwaped.Contains(new Tuple<int, int>(rndIndex1, rndIndex2)));
                alreadySwaped.Add(new Tuple<int, int>(rndIndex1, rndIndex2));
                var swappingChar = strArray[rndIndex1];
                strArray[rndIndex1] = strArray[rndIndex2];
                strArray[rndIndex2] = swappingChar;
            }
            return new string(strArray);
        }
        public static string GeneratePassword(PasswordComplexity complexityLevel)
        {
            switch (complexityLevel)
            {
                case PasswordComplexity.Simple: return GenerateSimplePassword();
                case PasswordComplexity.Medium: return GenerateMediumPassword();
                case PasswordComplexity.Strong: return GenerateStrongPassword();
                case PasswordComplexity.Stronger: return GenerateStrongerPassword();
            }
            return null;
        }
        private static string GenerateSimplePassword()
        {
            return GenerateRandomString(6, 9);
        }
        private static string GenerateMediumPassword()
        {
            var passLen = RandomUtils.GetRandom(6, 10);
            var numCount = RandomUtils.GetRandom(1, 3);
            var alphaStr = GenerateRandomString(passLen - numCount);
            var numStr = GenerateString(Numbers, numCount);
            var pass = alphaStr + numStr;
            return Shuffle(pass);
        }
        private static string GenerateStrongPassword()
        {
            var lowerCharCount = RandomUtils.GetRandom(2, 5);
            var upperCharCount = RandomUtils.GetRandom(2, 5);
            var numCount = RandomUtils.GetRandom(2, 4);
            var spCharCount = RandomUtils.GetRandom(2, 4);
            var lowerAlphaStr = GenerateString(LowerAlpha, lowerCharCount);
            var upperAlphaStr = GenerateString(UpperAlpha, upperCharCount);
            var spCharStr = GenerateString(SpecialChars, spCharCount);
            var numStr = GenerateString(Numbers, numCount);
            var pass = lowerAlphaStr + upperAlphaStr + spCharStr + numStr;
            return Shuffle(pass);
        }
        private static string GenerateStrongerPassword()
        {
            var lowerCharCount = RandomUtils.GetRandom(5, 12);
            var upperCharCount = RandomUtils.GetRandom(4, 8);
            var numCount = RandomUtils.GetRandom(4, 6);
            var spCharCount = RandomUtils.GetRandom(4, 6);
            var lowerAlphaStr = GenerateString(LowerAlpha, lowerCharCount);
            var upperAlphaStr = GenerateString(UpperAlpha, upperCharCount);
            var spCharStr = GenerateString(SpecialChars, spCharCount);
            var numStr = GenerateString(Numbers, numCount);
            var pass = lowerAlphaStr + upperAlphaStr + spCharStr + numStr;
            return Shuffle(Shuffle(pass));
        }
        public enum PasswordComplexity
        {
            Simple, Medium, Strong, Stronger
        }
    }
