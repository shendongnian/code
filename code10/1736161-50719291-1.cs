        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            if (System.Windows.Application.Current != null)
            {
                System.Windows.Application.Current.Shutdown();
            }
        }
