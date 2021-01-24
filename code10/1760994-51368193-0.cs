    public  void FindItem<T1>(T1 id)
            {
                try
                {
                    
                    var obj = this;
                    // fill the object with the DB data
                    obj = Dal.ObjFind(new Production.ProductCategory(), id);
                    
                    PropertyDescriptorCollection PropertyObj = 
                     TypeDescriptor.GetProperties(this);
                    //iterating the properties in the instance of the class
                    foreach (PropertyDescriptor prop in PropertyObj)
                    {
                        //Get the value for each properties in the filled Obj
                        //and set that value for each properites in "this"
                        prop.SetValue (this,prop.GetValue(obj));
                    }
                   
                    
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
