    public sealed class Types
    {
        
        private readonly String name;
        private Types(String name)
        {
            this.name = name;
        }
        public override String ToString()
        {
            return name;
        }
        public static implicit operator Types(string str)
        {
            return new Types(str);
        }
        public static implicit operator string(Types str)
        {
            return str.ToString();
        }
        #region enum
        public const string DataType = "Data";
        public const string ImageType = "Image";
        public const string Folder = "Folder";
        #endregion
    }
