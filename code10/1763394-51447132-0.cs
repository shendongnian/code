    public class PropertyCopier<TSource, TDest> where TSource : class where TDest : class
    {
        private List<PropertyCopyPair> _propertiesToCopy = new List<PropertyCopyPair>();
        public PropertyCopier()
        {
            //get all the readable properties of the source type
            var sourceProps = new Dictionary<string, Tuple<Type, MethodInfo>>();
            foreach (var prop in typeof(TSource).GetProperties(BindingFlags.Instance | BindingFlags.Public))
            {
                if (prop.CanRead)
                {
                    sourceProps.Add(prop.Name, new Tuple<Type, MethodInfo>(prop.PropertyType, prop.GetGetMethod()));
                }
            }
            //now walk though the writeable properties of the destination type
            //if there's a match by name and type, keep track of them.
            foreach (var prop in typeof(TDest).GetProperties(BindingFlags.Instance | BindingFlags.Public))
            {
                if (prop.CanWrite)
                {
                    if (sourceProps.ContainsKey(prop.Name) && sourceProps[prop.Name].Item1 == prop.PropertyType)
                    {
                        _propertiesToCopy.Add (new PropertyCopyPair(prop.Name, prop.PropertyType, sourceProps[prop.Name].Item2, prop.GetSetMethod()));
                    }
                }
            }
        }
        public void Copy(TSource source, TDest dest)
        {
            foreach (var prop in _propertiesToCopy)
            {
                var val = prop.SourceReader.Invoke(source, null);
                prop.DestWriter.Invoke(dest, new []{val});
            }
        }
    }
