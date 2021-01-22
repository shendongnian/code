     using (Msi.Install msi = Msi.CustomActionHandle(_msiHandle))
     {
         using (Msi.Record record = new Msi.Record(100))
         {
             record.SetString(0, "LOG: [1]");
             record.SetString(1, entry.Message);
             msi.ProcessMessage(Msi.InstallMessage.Info, record);
         }
     }
