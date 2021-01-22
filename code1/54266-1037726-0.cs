      Patient pt = new Patient(12);
      pt.BeginEdit();
      pt.Name = args[0];
      pt.Address = args[1];
      if (WSCallIsOK())
         pt.EndEdit();       // save is OK
      else
         pt.CancelEdit();   // sets values back
