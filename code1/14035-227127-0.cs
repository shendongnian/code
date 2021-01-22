    foreach(UserControl uc in plhMediaBuys.Controls)
    {
      if (uc is MySpecificType)
      {
        return (uc as MySpecificType).PulblicPropertyIWantAccessTo;
      }
    }
