        public sealed class Types
    {
        private static readonly Dictionary<string, Types> strInstance = new Dictionary<string, Types>();
        private static readonly Dictionary<int, Types> intInstance = new Dictionary<int, Types>();
        private readonly String name;
        private static int layerTypeCount = 0;
        private int value;
        private Types(String name)
        {
            this.name = name;
            value = layerTypeCount++;
            strInstance[name] = this;
            intInstance[value] = this;
        }
        public override String ToString()
        {
            return name;
        }
        public static implicit operator Types(int val)
        {
            Types result;
            if (intInstance.TryGetValue(val, out result))
                return result;
            else
                throw new InvalidCastException();
        }
        public static implicit operator Types(string str)
        {
            Types result;
            if (strInstance.TryGetValue(str, out result))
            {
                return result;
            }
            else
            {
                result = new Types(str);
                return result;
            }
        }
        public static implicit operator string(Types str)
        {
            return str.ToString();
        }
        public static bool operator ==(Types a, Types b)
        {
            return a.value == b.value;
        }
        public static bool operator !=(Types a, Types b)
        {
            return a.value != b.value;
        }
        #region enum
        public const string DataType = "Data";
        public const string ImageType = "Image";
        #endregion
    }
