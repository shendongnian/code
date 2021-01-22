        public virtual bool IsSubclassOf(Type c)
        {
            Type baseType = this;
            if (!(baseType == c))
            {
                while (baseType != null)
                {
                    if (baseType == c)
                    {
                        return true;
                    }
                    baseType = baseType.BaseType;
                }
                return false;
            }
            return false;
        }
