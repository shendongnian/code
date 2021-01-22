     private void DoWebService()
     {
          try
          {
               MyWebService.MyWebserviceWSE WSE = new MyWebService.MyWebserviceWSE.MyWebserviceWSE();
               WSE.DoSomethingCompleted += new MyWebService.DoSomethingCompletedEventHandler(WSE_DoSomethingCompleted);
               WSE.DoSomethingAsync(/* pass arguments to webservice */);            
          }
          catch (Exception ex)
          {
               // Handle errors
          }
     }
     private void WSE_DoSomethingCompleted(object o, MyWebService.DoSomethingCompletedEventArgs args)
     {
          if (args.Error != null)
          {
               // The following gets the error and shows it in a msg box
               StringBuilder sb = new StringBuilder();
               sb.AppendLine(args.Error.ToString());
               if (args.Error.InnerException != null)
               {
                   sb.AppendLine(args.Error.ToString());
               }
               MessageBox.Show(sb.ToString());
          }
          else
          {
               // Do something with the results
          }
     }
