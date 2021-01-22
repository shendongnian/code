        public object GetDeserializedObject<T>(object obj)
        {
            if (obj is Array)
            {
                var list = ((Array)obj).Cast<T>().ToList();
                obj = list;
            }
            return obj;
        }
