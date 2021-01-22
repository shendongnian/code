    /// <summary>
            /// Covert a data table to an entity wiht properties name same as the repective column name
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="dt"></param>
            /// <returns></returns>
            public static List<T> ConvertDataTable<T>(this DataTable dt)
            {
                List<T> models = new List<T>();
                foreach (DataRow dr in dt.Rows)
                {
                    T model = (T)Activator.CreateInstance(typeof(T));
                    PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
    
                    foreach (PropertyDescriptor prop in properties)
                    {
                        //get the property information based on the type
                        System.Reflection.PropertyInfo propertyInfo = model.GetType().GetProperties().Last(p => p.Name == prop.Name);
    
                        var ca = propertyInfo.GetCustomAttribute<PropertyDbParameterAttribute>(inherit: false);
                        string PropertyName = string.Empty;
                        if (ca != null && !String.IsNullOrWhiteSpace(ca.name) && dt.Columns.Contains(ca.name))  //Here giving more priority to explicit value
                            PropertyName = ca.name;
                        else if (dt.Columns.Contains(prop.Name))
                            PropertyName = prop.Name;
    
                        if (!String.IsNullOrWhiteSpace(PropertyName))
                        {
                            //Convert.ChangeType does not handle conversion to nullable types
                            //if the property type is nullable, we need to get the underlying type of the property
                            var targetType = IsNullableType(propertyInfo.PropertyType) ? Nullable.GetUnderlyingType(propertyInfo.PropertyType) : propertyInfo.PropertyType;
                            // var propertyVal = Convert.ChangeType(dr[prop.Name], targetType);
                            //Set the value of the property
                            try
                            {
                                if (propertyInfo.PropertyType.IsEnum)
                                    prop.SetValue(model, dr[PropertyName] is DBNull ? (object)null : Enum.Parse(targetType, Convert.ToString(dr[PropertyName])));
                                else
                                    prop.SetValue(model, dr[PropertyName] is DBNull ? (object)null : Convert.ChangeType(dr[PropertyName], targetType));
                            }
                            catch (Exception ex)
                            {
                                //Logging.CustomLogging(loggingAreasType: LoggingAreasType.Class, loggingType: LoggingType.Error, className: CurrentClassName, methodName: MethodBase.GetCurrentMethod().Name, stackTrace: "There's some problem in converting model property name: " + PropertyName + ", model property type: " + targetType.ToString() + ", data row value: " + (dr[PropertyName] is DBNull ? string.Empty : Convert.ToString(dr[PropertyName])) + " | " + ex.StackTrace);
                                throw;
                            }
                        }
                    }
                    models.Add(model);
                }
                return models;
            }
