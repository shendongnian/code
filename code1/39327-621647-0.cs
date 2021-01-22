    foreach (string objectName in this.ObjectNames)
    {
        // Line to jump to when this.MoveToNextObject is true.
        this.ExecuteSomeCode();
        while (this.boolValue)
        {
            if (this.MoveToNextObject())
            {
                // What should go here to jump to next object.
                break;
            }
        }
        if (! this.boolValue) continue; // continue foreach
    
        this.ExecuteSomeOtherCode();
    }
