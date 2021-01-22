    foreach (Control ctrl in Form1.Controls)
    {
        if (ctrl.GetType() == typeof(PictureBox))
        { 
            if (((PictureBox)ctrl).Tag == ((PictureBox)sender).Tag)
            {
                ctrl.Hide();
            }
            else
            {
                ctrl.Show();
            }
        }
    }
