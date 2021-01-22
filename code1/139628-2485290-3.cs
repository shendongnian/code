    public abstract class GenericDataList<T> : List<T> where T : BaseDataClass
    {
        protected void InitializeList(string sql)
        {
            DataHandler dh = new DataHandler(); // my general database class
            DataTable dt = dh.RetrieveData(sql); 
            if (dt != null)
            {
                this.InitializeList(dt);
                dt.Dispose();
            }
            dt = null;
            dh = null;
        }
        protected void InitializeList(DataTable dt)
        {
            if (dt != null)
            {
                Type type = typeof(T);
                MethodInfo methodInfo = type.GetMethod("InitializeClass");
                foreach (DataRow dr in dt.Rows)
                {
                    T t = Activator.CreateInstance<T>();
                    if (methodInfo != null)
                    {
                        object[] paramArray = new object[1];
                        paramArray[0] = dr;
                        methodInfo.Invoke(t, paramArray);
                    }
                    this.Add(t);
                }
            }
        }
    }
