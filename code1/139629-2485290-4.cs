            protected void InitializeList(DataTable dt)
            {
                if (dt != null)
                {
                    Type type = typeof(T);
    
                    foreach (DataRow dr in dt.Rows)
                    {
                        T t = Activator.CreateInstance<T>();
                        (t as BaseDataClass).InitializeClass(dr);
    
                        this.Add(t);
                    }
                }
            }
