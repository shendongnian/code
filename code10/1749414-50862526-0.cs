        public void DisplayCard(string SPID, string strAssetDirectory)
        {
            using (ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client())
            {
                using (Stream ms = proxy.GetServiceCard(SPID, strAssetDirectory))
                {
                  try
                  {
                     using (file = new FileStream(Properties.Settings.Default.ServiceCardDisplayPath, FileMode.Create, FileAccess.Write))
                     {
                         ms.CopyTo(file);
                         file.Close();
                     }
                 }
                 catch (Exception ex)
                 {
                     MessageBox.Show(ex.Message);
                 }
             }
           }
        
         ServiceCardBrowser.Navigate(
             $"file://{Properties.Settings.Default.ServiceCardDisplayPath}");
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            File.Delete(Properties.Settings.Default.ServiceCardDisplayPath);
        
            this.Owner.Focus();
        }
