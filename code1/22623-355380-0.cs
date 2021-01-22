    string targeturl= "http://stackoverflow.com";
    try
        {
         System.Diagnostics.Process.Start(targeturl);
        }
    catch
        ( 
         System.ComponentModel.Win32Exception noBrowser) 
        {
         if (noBrowser.ErrorCode==-2147467259)
          MessageBox.Show(noBrowser.Message);
        }
    catch (System.Exception other)
        {
          MessageBox.Show(other.Message);
        }
