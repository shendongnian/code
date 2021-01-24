    public override int GetHashCode()
            {
                int hash = 57;
                var props = GetType().GetProperties();
    
                UInt32 crc = 0;
                foreach (var p in props)
                {
                    if (!p.GetCustomAttributes(typeof(YourAttribute), true).Any())
                    {
                        if (p.GetValue(this, null) != null)
                            hash = 27 ^ hash ^ p.GetValue(this, null).GetHashCode();
    
                    }
                }
                return hash;
            }
