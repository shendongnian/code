    bool repos = false;
    Point p;
    foreach (Control item in panelContenedor.Controls.OfType<Control>())
        {
            if (repos)
            {
                 Point tmp = item.Location;              
                 item.Location = p;
                 p = tmp;
            }
            if (item.Name == nombreTextBox)
            {
                panelContenedor.Controls.Remove(item);
                panelContenedor.Controls.Remove(bt);
                repos = true;
                p = item.Location;
            }
    
        }
