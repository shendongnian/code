        if (IsChanged)
        {
            return;
        }
        else if (Status == "") // Executed when the close (x) button is pressed, as the Status string is not yet set to a real value...
        {
            CancelClose();
        }
        else if (Status == "saving") // saving logic falls to here...
        {
            //     IsChanged = false;
        }
