             void findPapaTab(Control ctrl)
            {
                foreach (TabItem item in ImTheTabControl.Items)
                {
                    if (null != UIHelper.FindChild<TextBox>(item.Content as Grid, ImTheTextbox.Name))
                    {
                        MessageBox.Show(item.Name);
                    }
                }
            }
