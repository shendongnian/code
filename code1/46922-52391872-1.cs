    public static class ObjectMapper
    {
        // the target object is created on the fly and the target type 
        // must have a parameterless constructor (either compiler-generated or explicit) 
        public static Ttarget MapToNewObject<Ttarget>(object sourceobject) where Ttarget : new()
        {
            // create an instance of the target class
            Ttarget targetobject = (Ttarget)Activator.CreateInstance(typeof(Ttarget));
            // map the source properties to the target object
            MapToExistingObject(sourceobject, targetobject);
            return targetobject;
        }
        // the target object is created beforehand and passed in
        public static void MapToExistingObject(object sourceobject, object targetobject)
        {
            // get the list of properties available in source class
            var sourceproperties = sourceobject.GetType().GetProperties().ToList();
            // loop through source object properties
            sourceproperties.ForEach(sourceproperty => {
                var targetProp = targetobject.GetType().GetProperty(sourceproperty.Name);
                
                // check whether that property is present in target class and is writeable
                if (targetProp != null && targetProp.CanWrite)
                {
                    // if present get the value and map it
                    var value = sourceobject.GetType().GetProperty(sourceproperty.Name).GetValue(sourceobject, null);
                    targetobject.GetType().GetProperty(sourceproperty.Name).SetValue(targetobject, value, null);
                }
            });
        }
    }
