    while (panel1.Controls.Count == 0)
            {
                foreach (Control c in panel1.Controls)
                {
                    panel1.Controls.Remove(c);
                }
            }
