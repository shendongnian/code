    public delegate void AddControlToPanelDlg(Panel p, Control c);
    
            private void AddControlToPanel(Panel p, Control c)
            {
                p.Controls.Add(c);
            }
            
            private void AddNewContol(object state)
            {
                object[] param = (object[])state;
                Panel p = (Panel)param[0];
                Control c = (Control)param[1]
                if (p.InvokeRequired)
                {
                    p.Invoke(new AddControlToPanelDlg(AddControlToPanel), p, c);
                }
                else
                {
                    AddControlToPanel(p, c);
                }
            }
        
