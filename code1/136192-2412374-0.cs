    public class Money : IAmout {
        private Dictionary<string, decimal> _dict;
    
        public decimal this[string fieldName] {
            get { return _dict[fieldName]; }
            set { _dict[fieldName] = value; }
        }
    }
