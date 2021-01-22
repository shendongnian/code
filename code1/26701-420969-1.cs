        // Get the Type of a property by reflection.
        Type myPropType = typeof(Program).GetProperty("SomeProp").PropertyType;
           
        // Now call a generic method just using the type
        typeof(Program).GetMethod("WhatAmI",
            BindingFlags.Static | BindingFlags.NonPublic)
                .MakeGenericMethod(myPropType).Invoke(null, null);
