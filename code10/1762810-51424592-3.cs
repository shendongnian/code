    foreach (PropertyInfo propertyinfo in typeof(yourClass).GetProperties())
            {
               if(propertyinfo !=null){
				var valueOfField=propertyinfo.GetValue(yourobject);
				var fieldname = propertyinfo.Name;
                if (valueOfField!=null && fieldname != null)
                {
                  string data=fieldname +"="+valueOfField
                }
              }
            }
