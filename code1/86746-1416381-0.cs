            String sitePath = null;
            try
            {
                sitePath = Application.StartupPath + @"\Print_Help\help.html";
                wbHelp.Navigate(sitePath);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString() + "\nSite Path: " + sitePath);
                return false;
            }
            return true;
