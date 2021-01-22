    Type target = typeof(DisabilityPaymentAddEntity);
    foreach(PropertyInfo pi in display.GetType().GetProperties())
    {
         PropertyInfo targetProp = target.GetProperty(pi.Name, null);
         if(targetProp!=null)
         {
            targetprop.SetValue(this, pi.GetValue(display), null);
         }
    }
