    var objectToCopy = sensorGet.SensorGetResult[0];
    var helperArray = new WhatEverTypeIsYourHelperArray {
        Property1 = objectToCopy.Property1,
        Property2 = objectToCopy.Property2,
        // etc.
    };
    sensorGet.SensorGetResult.Add(helperArray);
