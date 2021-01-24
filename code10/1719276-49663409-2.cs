    Task.Run(async () =>
       {
          while (!_isCancled)
          {
             await Task.Delay(2000);
             //SendKeys.Send("KeyBoard Action");
             Console.WriteLine("blah");    
          }
       });
