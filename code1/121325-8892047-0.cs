        /// <summary>
        /// check deep property
        /// </summary>
        /// <param name="obj">instance</param>
        /// <param name="property">deep property not include instance name example "A.B.C.D.E"</param>
        /// <returns>if null return true else return false</returns>
        public static bool IsNull(this object obj, string property)
        {
            if (string.IsNullOrEmpty(property) || string.IsNullOrEmpty(property.Trim())) throw new Exception("Parameter : property is empty");
            if (obj != null)
            {
                string[] deep = property.Split('.');
                object instance = obj;
                Type objType = instance.GetType();
                PropertyInfo propertyInfo;
                foreach (string p in deep)
                {
                    propertyInfo = objType.GetProperty(p);
                    if (propertyInfo == null) throw new Exception("No property : " + p);
                    instance = propertyInfo.GetValue(instance, null);
                    if (instance != null)
                        objType = instance.GetType();
                    else
                        return true;
                }
                return false;
            }
            else
                return true;
        }
