    if (inputs.FirstOrDefault(i =>
            typeof(SoapAuthBase).IsAssignableFrom(i.GetType())) 
            is SoapAuthBase authenticationContract){
      // authenticationContract exists
    }
    // authenticationContract does not exist
