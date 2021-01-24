    if (panelContenedor.Controls.Count > 6) //it is six because i have 5 controls and when i open a form it turns to six, so if i have a sixth control it means that i have a form open and so i must close it
            {
                panelContenedor.Controls.RemoveAt(6);                                    
            }
            
            Form fh = formHijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(fh);
            this.panelContenedor.Tag = fh;
            fh.Show();
