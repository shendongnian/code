      public override int GetHashCode()
            {
                int hash = 57;
                if (Field1 != null)
                     hash = 27 ^ hash ^ Field1.GetHashCode();
                if (Field2 != null)
                     hash = 27 ^ hash ^ Field2.GetHashCode();              
                return hash;
            }
