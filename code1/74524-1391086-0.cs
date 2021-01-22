        public static Dictionary<int, string> EnumToList(Type t)
        {
            Dictionary<int, string> list = new Dictionary<int, string>();
            foreach (var v in Enum.GetValues(t))
            {
                list.Add((int)v, Enum.GetName(t, (int)v));
            }
            
            return list;
        }
