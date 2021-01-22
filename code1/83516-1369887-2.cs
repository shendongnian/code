    public class LocalizableEnum
    {
        /// <summary>
        /// Column names exposed by LocalizableEnum
        /// </summary>
        public class ColumnNames
        {
            public const string ID = "EnumValue";
            public const string EntityValue = "EnumDescription";
        }
    }
    public class LocalizableEnum<T>
    {
        private T m_ItemVal;
        private string m_ItemDesc;
        public LocalizableEnum(T id)
        {
            System.Enum idEnum = id as System.Enum;
            if (idEnum == null)
                throw new ArgumentException(string.Format("Type {0} is not enum", id.ToString()));
            else
            {
                m_ItemVal = id;
                m_ItemDesc = idEnum.GetDescription();
            }
        }
        public override string ToString()
        {
            return m_ItemDesc;
        }
        public T EnumValue
        {
            get { return m_ID; }
        }
        public string EnumDescription
        {
            get { return ToString(); }
        }
    }
