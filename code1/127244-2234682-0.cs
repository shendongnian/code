       string invokeMethod = GetValueFromDB()  //ur logic to get the SMA or EMA or TMA from db
       Type urType=typeof("yourclassname");
       object unKnownObj = Activator.CreateInstance(urType);
       //Fill your paramters to ur method(SMA,EMA) here
       //ie, sma.sma(UITAName, YVal, UITPeriod, UITShift);           
       object[] paramValue = new object[4];
       paramValue[0] = UITAName;
       paramValue[1] = YVal;
       paramValue[2] = UITPeriod;
       paramValue[3] = UITShift;
       object result=null;
            try
            {
                result = urType.InvokeMember(invokeMethod, System.Reflection.BindingFlags.InvokeMethod, null, unKnownObj, paramValue);
                
                 
            }
            catch (Exception ex)
            {
                //Ex handler
            }
