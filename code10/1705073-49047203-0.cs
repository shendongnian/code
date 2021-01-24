    static async void SendNotification() { // if you hate async void - use Task
         try {
            await iPushNotificationService.SendPushNotification(objNotificationMessage);
         }
         catch (Exception ex {
             // log it
         }
    }
