       public class Key
       {
            string name;
            public override int GetHashCode()
            {
                 return name.GetHashCode();
            }
    
            public override bool Equals(object obj)
            {
                if (obj == null)
                {
                  return false;
                }
    
                Key objAsKey = obj as Key;
                if (objAsKey == null)
                {
                  return false;
                }
    
                return this.name.Equals(objAsKey.Name);
            }
        }
