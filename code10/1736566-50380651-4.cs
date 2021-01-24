    public static T Fill(DataRow row)
        {
            int id = Convert.ToInt32(row["id"].ToString());
            string name = row["name"].ToString();
            T o = new T();
            o.id = id;
            o.name = name;
            return o;
        }
        public static List<T> FillAll(DataRowCollection rows)
        {
            List<T> objs = new List<T>();
            foreach (DataRow row in rows)
            {
                T o = Fill(row);
                if (o != null)
                    objs.Add(o);
            }
            return objs;
        }
