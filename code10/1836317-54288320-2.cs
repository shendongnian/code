       int counter = 0;
       while(true)
       {
           if(counter == 20)
           {
               counter = 0;
               System.Threading.Thread.Sleep(50000);
           }
           //Here you need to add code for sending emails and breaking the while loop when you are done
           SmtpServer.Send(message);
           counter++;
       }
