    private static void InitClient<T>(ClientBase<T> client) where T : class
    { 
       client.Endpoint.Binding.CloseTimeout = new TimeSpan(12, 0, 0); 
       client.Endpoint.Binding.ReceiveTimeout = new TimeSpan(12, 0, 0); 
       client.Endpoint.Binding.SendTimeout = new TimeSpan(12, 0, 0); 
       client.Endpoint.Binding.OpenTimeout = new TimeSpan(12, 0, 0); 
    }
