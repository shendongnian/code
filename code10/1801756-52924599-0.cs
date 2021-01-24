    public class BaseRecord {
        public Type IdType { get; }
        private Object _id = null;
        public Object Id { 
            get {
                return _id;
            }
            set {
                if(value != null) {
                    if(!IdType.IsAssignableFrom(value.GetType()))
                        throw new Exception("IdType mismatch");
                }
                _id = value;
            }
        }
        public bool IsActive { get; set; }
        public DateTime CreatedTime { get; set; }
        public BaseRecord(Type idType)
        {
            if(idType == null) throw new ArgumentNullException("idType");
            this.IdType = idType;
        }
    }
    namespace Generic {
        public class BaseRecord<T> : BaseRecord
        {
            public BaseRecord() : base(typeof(T))            
            {
            }
        }
    }
    public class User : Generic.BaseRecord<int>
    {}
    public class OtherRecord : Generic.BaseRecord<string>
    {}
    // This inheritence scheme gives you the flexibility to non-generically reference record objects 
    // which can't be done if you only have generic base classes
    BaseRecord r = new User();
    r = new OtherRecord();
    BaseRecord records[] = { new User(), new OtherRecord() };
