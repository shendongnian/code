            #region ConvertingToEnum
            private int val;
            static Dictionary<int, string> dict = null;
            public Orientation(int val)
            {
                this.val = val;
            }
            public static implicit operator Orientation(int value)
            {
                return new Orientation(value - 1);
            }
            public static bool operator ==(Orientation a, Orientation b)
            {
                return a.val == b.val;
            }
            public static bool operator !=(Orientation a, Orientation b)
            {
                return a.val != b.val;
            }
            public override string ToString()
            {
                if (dict == null)
                    InitializeDict();
                if (dict.ContainsKey(val))
                    return dict[val];
                return val.ToString();
            }
            private void InitializeDict()
            {
                dict = new Dictionary<int, string>();
                foreach (var fields in GetType().GetFields(BindingFlags.Public | BindingFlags.Static))
                {
                    dict.Add(((Orientation)fields.GetValue(null)).val, fields.Name);
                }
            } 
            #endregion
