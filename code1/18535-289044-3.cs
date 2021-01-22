    public class Test
    {
       public void OnError(object sender, ErrorEventArgs args)
       {
        	Console.WriteLine(args.Message);
       }
     }
     Test t = new Test();
     Service.OnError += t.OnError;
     Service.SaveMyMessage("Test message");
