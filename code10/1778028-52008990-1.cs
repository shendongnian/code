    private void ClientReceiveData(object sender, ConnectedClient.NetDataEventArgs e)
    {
        double[] result = null; 
        if (string.IsNullOrEmpty(e.Message) == false)
        {
            if (e.ID == 0)
            {
                //float.Parse(e.Message, CultureInfo.InvariantCulture.NumberFormat);
                result = Array.ConvertAll(e.Message.Split(new [] {','}, StringSplitOptions.RemoveEmptyEntries), ParseWithError);
                Trace.WriteLine(String.Join(Environment.NewLine, e.Message));
            }
    
            if (e.ID == 1)
            {
                //float.Parse(e.Message, CultureInfo.InvariantCulture.NumberFormat);
                result = Array.ConvertAll(e.Message.Split( new [] {','}, StringSplitOptions.RemoveEmptyEntries), ParseWithError);
                Trace.WriteLine(String.Join(Environment.NewLine, e.Message));
            }
        }
    }
    double ParseWithError(string value) 
    {
         double result;
         if (!double.TryParse(value, out result))
         {
             throw new ApplicationException("Error parsing value " + value,e);
         }
         return result;
    }
