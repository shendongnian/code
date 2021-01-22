        // Do stuff before.
        // Start the message box -thread:
        new Thread(new ThreadStart(delegate
        {
          MessageBox.Show
          (
            "Hey user, stuff runs in the background!", 
            "Message",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning
          );
        })).Start();
        // Continue doing stuff while the message box is visible to the user.
        // The message box thread will end itself when the user clicks OK.
    
