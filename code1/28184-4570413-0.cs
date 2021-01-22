    public static object ToNonAnonymousList<T>(this List<T> list, Type t)
        {
            //define system Type representing List of objects of T type:
            Type genericType = typeof (List<>).MakeGenericType(t);
            //create an object instance of defined type:
            object l = Activator.CreateInstance(genericType);
            //get method Add from from the list:
            MethodInfo addMethod = l.GetType().GetMethod("Add");
            //loop through the calling list:
            foreach (T item in list)
            {
                //convert each object of the list into T object by calling extension ToType<T>()
                //Add this object to newly created list:
                addMethod.Invoke(l, new[] {item.ToType(t)});
            }
            //return List of T objects:
            return l;
        }
        public static object ToType<T>(this object obj, T type)
        {
            //create instance of T type object:
            object tmp = Activator.CreateInstance(Type.GetType(type.ToString()));
            //loop through the properties of the object you want to covert:          
            foreach (PropertyInfo pi in obj.GetType().GetProperties())
            {
                try
                {
                    //get the value of property and try to assign it to the property of T type object:
                    tmp.GetType().GetProperty(pi.Name).SetValue(tmp, pi.GetValue(obj, null), null);
                }
                catch (Exception ex)
                {
                    Logging.Log.Error(ex);
                }
            }
            //return the T type object:         
            return tmp;
        }
