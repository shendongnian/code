                int n;
                n = panel1.Controls.Count-1;
    
                for (int i = 0; i <= n; i++ )
                {
                    Control c = panel1.Controls[0];
                    panel1.Controls.Remove(c);
                }
