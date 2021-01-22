    foreach(UserControl uc in plhMediaBuys.Controls)
    {
        ParticularUCType myControl = uc as ParticularUCType;
        if (myControl != null)
        {
            // do stuff with myControl.PulblicPropertyIWantAccessTo;
        }
    }
