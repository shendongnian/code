    public class MyClass
    {
        private static readonly Encoding koreanEncoding = Encoding.GetEncoding("EUC-KR");
        [XmlIgnore]
        public byte[] pName;
        public string pNameString
        {
            get => koreanEncoding.GetString(pName).TrimEnd('\0');
            set
            {
                pName = koreanEncoding.GetBytes(value);
                Array.Resize(ref temp, 32);
                pName = temp;
            }
        }
    }
