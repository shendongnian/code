    private void Services_Form_FormClosing(object sender, FormClosingEventArgs e)
            {
                Properties.Settings.Default.combo_main_srvc.Clear();
    
                foreach (object items in combo_delete_main_srvc.Items)
                {
                    Properties.Settings.Default.combo_main_srvc.Add(items.ToString());
                }
                Properties.Settings.Default.Save();
            }
