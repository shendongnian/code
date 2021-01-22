    public D Map<D, S>(S enumValue, D defaultValue)
        {
            
            D se = defaultValue; 
            string n = Enum.GetName(typeof(S), enumValue);
            
            string[] s = Enum.GetNames(typeof(S));
            string[] d = Enum.GetNames(typeof(D));
            foreach (var v in d)
            {
                if (n.Substring(1, n.Length - 1) == v.Substring(1, v.Length - 1))
                {
                    se = (D)Enum.Parse(typeof(D), v);
                    break;
                }
            }
            return se;
        }
