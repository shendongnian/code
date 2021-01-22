        public struct EntityName
        {
            public Numbers _num;
            public string _caption;
            public EntityName(Numbers type, string caption)
            {
                _type = type;
                _caption = caption;
            }
            public Number GetNumber() 
            {
                return _type;
            }
            public override string ToString()
            {
                return this._caption;
            }
        }
