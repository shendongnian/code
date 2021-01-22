    Type target = typeof(DisabilityPaymentAddEntity);
    foreach(PropertyInfo pi in display.GetType().GetProperties())
    {
         PropertyInfo targetProp = target.GetProperty(pi.Name);
         if(targetProp!=null)
         {
            targetProp.SetValue(this, pi.GetValue(display, null), null);
         }
    }
