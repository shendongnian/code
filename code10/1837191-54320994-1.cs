        private List<RadioButton> rblist = new List<RadioButton>();
        private void GetCheckedRB(Panel pnl, string groupName)
        {
            foreach (Control ctrl in pnl.Controls)
            {
                if (ctrl is RadioButton)
                {
                    RadioButton rb = (RadioButton)ctrl;                    
                    if (rb.GroupName == groupName && rb.Checked)
                        rblist.Add(rb);
                }
            }
            //Put action here
            //MessageBox.Show(String.Join(", ", rblist.Select(x => x.Name).ToArray().ToString()));
        }
