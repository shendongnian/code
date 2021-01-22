namespace System.Text
{
    public class Latin1Encoding : Encoding
    {
        private readonly string m_specialCharset = (char) 0xA0 + @"¡¢£¤¥¦§¨©ª«¬­®¯°±²³´µ¶·¸¹º»¼½¾¿ÀÁÂÃÄÅÆÇÈÉÊËÌÍÎÏÐÑÒÓÔÕÖ×ØÙÚÛÜÝÞßàáâãäåæçèéêëìíîïðñòóôõö÷øùúûüýþÿ";
        public override string WebName
        {
            get { return @"ISO-8859-1"; }
        }
        public override int CodePage
        {
            get { return 28591; }
        }
        public override int GetByteCount(char[] chars, int index, int count)
        {
            return count;
        }
        public override int GetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex)
        {
            if (chars == null)
                throw new ArgumentNullException(@"chars", @"null array");
            if (bytes == null)
                throw new ArgumentNullException(@"bytes", @"null array");
            if (charIndex < 0)
                throw new ArgumentOutOfRangeException(@"charIndex");
            if (charCount < 0)
                throw new ArgumentOutOfRangeException(@"charCount");
            if (chars.Length - charIndex < charCount)
                throw new ArgumentOutOfRangeException(@"chars");
            if (byteIndex < 0 || byteIndex > bytes.Length)
                throw new ArgumentOutOfRangeException(@"byteIndex");
            for (int i = 0; i < charCount; i++)
            {
                char ch = chars[charIndex + i];
                int chVal = ch;
                bytes[byteIndex + i] = chVal < 160 ? (byte)ch : (chVal <= byte.MaxValue ? (byte)m_specialCharset[chVal - 160] : (byte)63);
            }
            return charCount;
        }
        public override int GetCharCount(byte[] bytes, int index, int count)
        {
            return count;
        }
        public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex)
        {
            if (chars == null)
                throw new ArgumentNullException(@"chars", @"null array");
            if (bytes == null)
                throw new ArgumentNullException(@"bytes", @"null array");
            if (byteIndex < 0)
                throw new ArgumentOutOfRangeException(@"byteIndex");
            if (byteCount < 0)
                throw new ArgumentOutOfRangeException(@"byteCount");
            if (bytes.Length - byteIndex < byteCount)
                throw new ArgumentOutOfRangeException(@"bytes");
            if (charIndex < 0 || charIndex > chars.Length)
                throw new ArgumentOutOfRangeException(@"charIndex");
            for (int i = 0; i < byteCount; ++i)
            {
                byte b = bytes[byteIndex + i];
                chars[charIndex + i] = b < 160 ? (char)b : m_specialCharset[b - 160];
            }
            return byteCount;
        }
        public override int GetMaxByteCount(int charCount)
        {
            return charCount;
        }
        public override int GetMaxCharCount(int byteCount)
        {
            return byteCount;
        }
    }
}
