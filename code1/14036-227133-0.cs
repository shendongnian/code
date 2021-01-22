    foreach(UserControl uc in plhMediaBuys.Controls) {
        MyControl c = uc as MyControl;
        if (c != null) {
            c.PublicPropertyIWantAccessTo;
        }
    }
