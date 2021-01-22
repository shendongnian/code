     /// <summary>
        /// output all properties and values of obj
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="separator">default as ";"</param>
        /// <returns>properties and values of obj,with specified separator </returns>
        /// <Author>ligaoren</Author>
        public static string Dump(object obj, string separator)
        {
            try
            {
                if (obj == null)
                {
                    return string.Empty;
                }
                if (string.IsNullOrEmpty(separator))
                {
                    separator = ";";
                }
                Type t = obj.GetType();
                StringBuilder info = new StringBuilder(t.Name).Append(" Values : ");
                foreach (PropertyInfo item in t.GetProperties())
                {
                    object value = t.GetProperty(item.Name).GetValue(obj, null);
                    info.AppendFormat("[{0}:{1}]{2}", item.Name, value, separator);
                }
                return info.ToString();
            }
            catch (Exception ex)
            {
                log.Error("Dump Exception", ex);
                return string.Empty;
            }
        }
