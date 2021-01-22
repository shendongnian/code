    public bool AreEqual(object obj)
        {
            bool returnVal = true;
            if (this.GetType() == obj.GetType())
            {
                FieldInfo[] fields = this.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                foreach (FieldInfo field in fields)
                {
                    if(field.GetValue(this) != field.GetValue(obj))
                    {
                        returnVal = false;
                        break;
                    }
                }
            }
            else
                returnVal = false;
            return returnVal;
        }
