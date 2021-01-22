        private static bool ReadData<T>(XmlReader reader, string value, out T data)
        {
            bool result = false;
            try
            {
                reader.MoveToAttribute(value);
                object readData = reader.ReadContentAsObject();
                data = readData as T;
                if (data == null)
                {
                    // see if we can convert to the requested type
                    data = (T)Convert.ChangeType(readData, typeof(T));
                }
                result = (data != null);
            }
            catch (InvalidCastException) { }
            catch (Exception ex)
            {
                // add in any other exception handling here, invalid xml or whatnot
            }
            // make sure data is set to a default value
            data = (result) ? data : default(T);
            return result;
        }
