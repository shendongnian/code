    foreach(var shavaControl in shavaControls)
    {
        switch(shavaControl.Status)
        {
            case 1:
            shavaControl.Control.Status = MyCustControl.Status.First;
            break;
            case 2:
            shavaControl.Control.Status = MyCustControl.Status.Second;
            break;
            //...
        }
    }
