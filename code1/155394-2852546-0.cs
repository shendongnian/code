    private void LaunchWPFApplication(string header, string pPath)
            {
                // Header - What loads in the tabs top portion.
                // Path   - Page where to send the user
    
                //Create a new browser tab object
                BrowserTab bt = tabMain.SelectedItem as BrowserTab;
                bt = new BrowserTab();
                bt.txtHeader.Text = header;
                bt.myParent = BrowserTabs;
    
                //Load in the path 
                try
                {
                    Type formType = Type.GetType(pPath); //Example "foobar.foobarUserControl,foobar"
                    bt.Content = Activator.CreateInstance(formType);
                }
                catch (ArgumentNullException)
                {
                    MessageBox.Show("The specified user control : " + pPath + " cannot be found");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error has occurred while loaded the specified user control : " + pPath + ". It includes the following message : \n" + ex);
                }
                //Add the browser tab and then focus     
                try
                {
                    BrowserTabs.Add(bt);
                }
                catch(InvalidOperationException)
                {
                    MessageBox.Show("Cannot add " + pPath + " into the tab control");
                }
                bt.IsSelected = true;
            }
