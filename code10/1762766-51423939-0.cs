    private void OnKeyDown(object sender, KeyEventArgs e)
    { 
     switch (e.KeyCode)
     {
        case Keys.E:
            DriveTheCar();
            break;
    
        case Keys.C:
            Application.Exit();
            break;
     }
    }
