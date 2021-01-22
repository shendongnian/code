          foreach(DataGridViewColumn c in myView.Columns)
                if (c.Width > myMax)
                {
                    c.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    c.Width = myMax;
                }
