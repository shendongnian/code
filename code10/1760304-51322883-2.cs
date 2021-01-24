    public static class BigIntegerExtensions
    {
        public static byte[] ToByteArrayBigEndianUnsigned(this BigInteger bi, int minSize = 0)
        {
            byte[] bytes = bi.ToByteArray();
            int length;
            if (bytes[bytes.Length - 1] != 0)
            {
                if (minSize == 0 || minSize <= bytes.Length)
                {
                    Array.Reverse(bytes);
                    return bytes;
                }
                length = bytes.Length;
            }
            else
            {
                length = bytes.Length - 1;
            }
            
            var bytes2 = new byte[minSize == 0 ? length : Math.Max(minSize, length)];
            for (int i = 0, j = bytes2.Length - 1; i < length && j >= 0; i++, j--)
            {
                bytes2[j] = bytes[i];
            }
            return bytes2;
        }
    }
    var bi1 = BigInteger.Parse("18597082174523508716390621410767314599038866539779750637065684697259605002694360104971398651747704217448206242771805831180528356170981586469477958663193117845356353634469679095227815268434823260637917891539622982485837392495877800705071553435850492058570460745900129552907596604479063007676795998193064078987369363544131073880694736862904482385332020513837955197528182597410203652025183467149166026077910473816908590029574674997850683021938033561647681780168764842253700974777073181357779101690539999736174329578178742236883520017849893817175274405622018571899733008344137833140207194792223664500885734080606246950229");
    var bi2 = BigInteger.Parse("65537");
    var bytes1 = bi1.ToByteArrayBigEndianUnsigned();
    var bytes2 = bi2.ToByteArrayBigEndianUnsigned();
    var pars = new RSAParameters();
    pars.Modulus = bytes1;
    pars.Exponent = bytes2;
