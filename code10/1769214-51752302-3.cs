         public static void CopyToModelProperties(object source, object target)
                {
                    Type _typeTarget = target.GetType();
                    Type _typeSrc = source.GetType();
        
    if (_typeSrc.GetInterfaces().Any(a => a.Name == "IEnumerable") && _typeSrc.IsGenericType && _typeTarget.IsGenericType)
                {
                    // Dynamic allows us to loop through a collection if it's type IEnumerable
                    dynamic _sourceList = source;
    
                    foreach (var _source in _sourceList)
                    {
                        // Create a temp class of the generic type of the target list
                        object _tempTarget = Activator.CreateInstance(_typeTarget.GetGenericArguments()[0]);
    
                        //Recursively call to map all child properties
                        CopyToModelProperties(_source, _tempTarget);
    
                        // Add to target collection passed in
                        target.GetType().GetMethod("Add").Invoke(target, new[] { _tempTarget });
                    }
    
                }   
    else
                    {
        
                        var results = from srcProp in _typeSrc.GetProperties()
                                      let targetProperty = _typeTarget.GetProperty(GetModelPropertyNameFromSqlAttribute(_typeTarget, srcProp.Name))
                                      where srcProp.CanRead
                                      && targetProperty != null
                                      && (targetProperty.GetSetMethod(true) != null && !targetProperty.GetSetMethod(true).IsPrivate)
                                      && (targetProperty.GetSetMethod().Attributes & MethodAttributes.Static) == 0
                                      //  && targetProperty.PropertyType.IsAssignableFrom(srcProp.PropertyType)
                                      select new { sourceProperty = srcProp, targetProperty = targetProperty };
        
                        foreach (var prop in results)
                        {
                            if (prop.targetProperty.CanWrite && prop.sourceProperty.CanRead)
                            {
                                object targetValue = prop.targetProperty.GetValue(target, null);
                                object sourceValue = prop.sourceProperty.GetValue(source, null);
        
                                if (sourceValue == null) { continue; }
        
                                //if (prop.sourceProperty.PropertyType.IsArray
                                //    && prop.targetProperty.PropertyType.IsArray
                                //    && sourceValue != null)
        
                                if(prop.sourceProperty.PropertyType.IsClass && prop.targetProperty.PropertyType != typeof(string))
                                {
                                    var destinationClass = Activator.CreateInstance(prop.targetProperty.PropertyType);
                                    object copyValue = prop.sourceProperty.GetValue(source);
        
                                    CopyToModelProperties(copyValue, destinationClass);
        
                                    prop.targetProperty.SetValue(target, destinationClass);
                                }// See if there is a better way to do this.
                                else if (prop.targetProperty.PropertyType.GetInterfaces().Any(a => a.Name == "IEnumerable") && prop.sourceProperty.PropertyType.IsGenericType
                                    && prop.targetProperty.PropertyType.IsGenericType
                                    && sourceValue != null)
                                {
                                    CopyToModelList(source, target, prop.targetProperty, prop.sourceProperty, sourceValue);
                                }
                                else
                                {
                                    // CopySingleData(source, target, prop.targetProperty, prop.sourceProperty, targetValue, sourceValue);
                                    prop.targetProperty.SetValue(target, prop.sourceProperty.GetValue(source, null), null);
                                }
                            }
        
                        }            
                    }
        
                   // return target;
                }
    
         private static void CopyToModelList(object source, object target, PropertyInfo piTarget, PropertyInfo piSource, object sourceValue)
                {
                    //  int _sourceLength = (int)source.GetType().InvokeMember("Count", BindingFlags.GetProperty, null, source, null);
        
                    // First create a generic collection that matches the piTarget being passed in.
        
                    var _listType = typeof(List<>);
    props.sourceProperty.PropertyType.GetGenericArguments();
                    var _genericTargetArgs = piTarget.PropertyType.GetGenericArguments();
                    var _concreteTargetType = _listType.MakeGenericType(_genericTargetArgs);
                    var _newtargetList = Activator.CreateInstance(_concreteTargetType);
        
                    dynamic _sourceList = piSource.GetValue(source, null);
    
                    foreach (var _source in _sourceList)
                    {
                        object _tempTarget = Activator.CreateInstance(piTarget.PropertyType.GetGenericArguments()[0]);
        
                        CopyToModelProperties(_source, _tempTarget);
        
                        // here we have to make recursive call to copy data and populate the target list.
                        //_targetList.Add(CopyObjectPropertyData(_source, (dynamic)new object()));
                        _newtargetList.GetType().GetMethod("Add").Invoke(_newtargetList, new[] { _tempTarget });
                    }
        
                    piTarget.SetValue(target, _newtargetList, null);
                }
    
       
    
         public static string GetModelPropertyNameFromSqlAttribute(Type model, string sqlName)
            {
                string _ret = "";
        
                var _property = model.GetProperties().Where(w => w.GetCustomAttributes<SLSqlTableAttribute>().Where(w1 => w1.FieldName == sqlName).Any()).FirstOrDefault();
        
                if(_property != null)
                {
                    _ret = _property.Name;
                }
        
                return _ret;
            }
