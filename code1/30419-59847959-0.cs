    public class EnumX<T> where T : struct
    {
        public T Code { get; set; }
        public string Description { get; set; }
        public EnumX(T code, string desc)
        {
            if (!typeof(T).IsEnum) throw new NotImplementedException();
            Code = code;
            Description = desc;
        }
        public class Helper
        {
            private List<EnumX<T>> codes;
            public Helper(List<EnumX<T>> codes)
            {
                this.codes = codes;
            }
            public string GetDescription(T code)
            {
                EnumX<T> e = codes.Where(c => c.Code.Equals(code)).FirstOrDefault();
                return e is null ? "Undefined" : e.Description;
            }
        }
    }
