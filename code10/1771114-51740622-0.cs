     foreach (Object item in list)
      {
        var props = item.GetType().GetProperties();
        var targetProps=targetItem.GetType().GetProperties();
        foreach (var prop in props)
        {
            foreach (var targetProp in targetProps)
            {
                if(prop.name==targetprop.name)
                {
                   //assign
                }
            } 
        }
      }
