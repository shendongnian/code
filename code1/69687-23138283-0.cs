        public virtual T CreateObject<T>()
        {
            if (typeof(T).IsSubclassOf(this.GetType()))
            {
                throw new InvalidCastException(this.GetType().ToString() + " does not inherit from " + typeof(T).ToString());
            }
            T ret = System.Activator.CreateInstance<T>();
            PropertyInfo[] propTo = ret.GetType().GetProperties();
            PropertyInfo[] propFrom = this.GetType().GetProperties();
            // for each property check whether this data item has an equivalent property
            // and copy over the property values as neccesary.
            foreach (PropertyInfo propT in propTo)
            {
                foreach (PropertyInfo propF in propFrom)
                {
                    if (propT.Name == propF.Name)
                    {
                        propF.SetValue(ret,propF.GetValue(this));
                        break;
                    }
                }
            }
            return ret;
        }
