     foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces()) {
         if (nic.OperationalStatus == OperationalStatus.Up){
             if (nic.Id == "yay!")
         }
     }
