        public static bool EditTask(MyTask task)
        {
            //make a backup object in case user clicks Cancel
            MyTask backupTask = new MyTask();
            CloneObject(task, backupTask);
            //dialog form uses data binding to the backupTask object
            MyTaskWindow f = new MyTaskWindow(backupTask);
            
            f.ShowDialog();
            if (f.DialogResult.HasValue && f.DialogResult.Value)
            {
                //user clicked "Ok" - clone everything back
                CloneObject(backupTask, task);
                return true;
            }
            else
            {                
                return false;
            }
        }
        //Reflection is used to clone object
        //copied from http://www.c-sharpcorner.com/UploadFile/ff2f08/deep-copy-of-object-in-C-Sharp/
        private static void CloneObject(object objSource, object objTarget)
        {
            //step : 1 Get the type of source object and create a new instance of that type
            Type typeSource = objSource.GetType();
            //object objTarget = Activator.CreateInstance(typeSource);
            //Step2 : Get all the properties of source object type
            PropertyInfo[] propertyInfo = typeSource.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            //Step : 3 Assign all source property to taget object 's properties
            foreach (PropertyInfo property in propertyInfo)
            {
                //Check whether property can be written to
                if (property.CanWrite)
                {
                    //Step : 4 check whether property type is value type, enum or string type
                    if (property.PropertyType.IsValueType || property.PropertyType.IsEnum || property.PropertyType.Equals(typeof(System.String)))
                    {
                        property.SetValue(objTarget, property.GetValue(objSource, null), null);
                    }
                    //else property type is object/complex types, so need to recursively call this method until the end of the tree is reached
                    else
                    {
                        object objPropertyValue = property.GetValue(objSource, null);
                        if (objPropertyValue == null)
                        {
                            property.SetValue(objTarget, null, null);
                        }
                        else
                        {
                            Type newTypeSource = objPropertyValue.GetType();
                            object newObjTarget = Activator.CreateInstance(newTypeSource);
                            CloneObject(objPropertyValue, newObjTarget);
                            property.SetValue(objTarget, newObjTarget, null);
                        }
                    }
                }
            }            
        }
