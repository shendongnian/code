        Dictionary<ObjectType, bool> expandStates = new Dictionary<ObjectType, bool>();
        public bool this[ObjectType key]
        {
            get
            {
                if (!expandStates.ContainsKey(key)) return false;
                return expandStates[key];
            }
            set
            {
                expandStates[key] = value;
            }
        }
