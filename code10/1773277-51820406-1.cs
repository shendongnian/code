    // Request both failure and success report
    Msg.DeliveryNotification = DeliveryNotificationOptions.OnFailure | 
    DeliveryNotificationOptions.OnSuccess; 
    
    int emailsSent = 0;
    
    try 
    { 
         Console.WriteLine("start to send email ..."); 
         smtp.Send(Msg); 
         emailsSent++;
         Console.WriteLine("email was sent successfully!");
          
    } 
    catch (Exception ex) 
    { 
         Console.WriteLine("failed to send email with the following error:"); 
         Console.WriteLine(ex.Message); 
    }
