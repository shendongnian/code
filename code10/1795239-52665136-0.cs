    try 
    {
         var SQMRegKey = Registry.LocalMachine.OpenSubKey("CurrentControlSet\\Control\\WMI\\Autologger", true);
         if(SQMRegKey != null)
         {
            SQMRegKey.DeleteSubKeyTree("SQMLogger");
            SQMRegKey.Close();
         }
    } 
    catch (Exception ex)
    {
         MessageBox.Show(this, ex.ToString());
    }
