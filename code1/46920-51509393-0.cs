       private void PopulateDerivedFromBase<TB,TD>(TB baseclass,TD derivedclass)
        {
            //get our baseclass properties
            var bprops = baseclass.GetType().GetProperties();
            foreach (var bprop in bprops)
            {
                //get the corresponding property in the derived class
                var dprop = derivedclass.GetType().GetProperty(bprop.Name);
                //if the derived property exists and it's writable, set the value
                if (dprop != null && dprop.CanWrite)
                    dprop.SetValue(derivedclass,bprop.GetValue(baseclass, null),null);
            }
        } 
