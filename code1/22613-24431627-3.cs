    public class ImmutableObject<T>
    {
        private readonly Func<IEnumerable<KeyValuePair<string, object>>> initContainer;
        
        protected ImmutableObject() {}
        protected ImmutableObject(IEnumerable<KeyValuePair<string,object>> properties)
        {
            var fields = GetType().GetFields().Where(f=> f.IsPublic);
            var fieldsAndValues =
                from fieldInfo in fields
                join keyValuePair in properties on fieldInfo.Name.ToLower() equals keyValuePair.Key.ToLower()
                select new  {fieldInfo, keyValuePair.Value};
            fieldsAndValues.ToList().ForEach(fv=> fv.fieldInfo.SetValue(this,fv.Value));
        }
        protected ImmutableObject(Func<IEnumerable<KeyValuePair<string,object>>> init)
        {
            initContainer = init;
        }
        protected T setProperty(string propertyName, object propertyValue, bool lazy = true)
        {
            Func<IEnumerable<KeyValuePair<string, object>>> mergeFunc = delegate
                                                                            {
                                                                                var propertyDict = initContainer == null ? ObjectToDictonary () : initContainer();
                                                                                return propertyDict.Select(p => p.Key == propertyName? new KeyValuePair<string, object>(propertyName, propertyValue) : p).ToList();
                                                                            };
            var containerConstructor = typeof(T).GetConstructors()
                .First( ce => ce.GetParameters().Count() == 1 && ce.GetParameters()[0].ParameterType.Name == "Func`1");
            return (T) (lazy ?  containerConstructor.Invoke(new[] {mergeFunc}) :  DictonaryToObject<T>(mergeFunc()));
        }
        private IEnumerable<KeyValuePair<string,object>> ObjectToDictonary()
        {
            var fields = GetType().GetFields().Where(f=> f.IsPublic);
            return fields.Select(f=> new KeyValuePair<string,object>(f.Name, f.GetValue(this))).ToList();
        }
        private static object DictonaryToObject<T>(IEnumerable<KeyValuePair<string,object>> objectProperties)
        {
            var mainConstructor = typeof (T).GetConstructors()
                .First(c => c.GetParameters().Count()== 1 && c.GetParameters().Any(p => p.ParameterType.Name == "IEnumerable`1") );
            return mainConstructor.Invoke(new[]{objectProperties});
        }
        public T ToObject()
        {
            var properties = initContainer == null ? ObjectToDictonary() : initContainer();
            return (T) DictonaryToObject<T>(properties);
        }
    }
