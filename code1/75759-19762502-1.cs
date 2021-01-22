        public static object GetObjProperty(object obj, string property)
        {
            Type t = obj.GetType();
            PropertyInfo p = t.GetProperty("Location");
            Point location = (Point)p.GetValue(obj, null);
            return location;
        }
