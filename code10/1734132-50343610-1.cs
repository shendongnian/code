     private async void OnSuspending(object sender, SuspendingEventArgs e)
     {
         var deferral = e.SuspendingOperation.GetDeferral();
         //TODO: Save application state and stop any background activity 
         DataPackageView clipboardContent = Windows.ApplicationModel.DataTransfer.Clipboard.GetContent();
         var dataPackage = new DataPackage();
         dataPackage.SetText(await clipboardContent.GetTextAsync());
         Clipboard.SetContent(dataPackage);          
      // Clipboard.Flush(); 
         deferral.Complete();
     }
