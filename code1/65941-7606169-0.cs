            SubCentreMessage actual;
            actual = target.FindSubCentreFullDetails(120); //for Albany
            SubCentreMessage s = new SubCentreMessage();
            
            //initialising s with the same values as 
            foreach (var property in actual.GetType().GetProperties())
            {
                PropertyInfo propertyS = s.GetType().GetProperty(property.Name);
                var value = property.GetValue(actual, null);
                propertyS.SetValue(s, property.GetValue(actual, null), null);
            }
