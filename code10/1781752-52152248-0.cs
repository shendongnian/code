    TaskCompletionSource<Object> CancelLoginTcs = new TaskCompletionSource<Object>();
    // Make button click handler method async
    private async void btncon_Click(object sender, EventArgs e)
    {
        try
        {
            // Make Cancel button visible, so that user can click on it
            btnCancel.Visible = true;
            // Prepare everything needed to start login
            //var strLogin = ...;
            //var pass = ...;
            //model.Connexion cm = new model.Connexion();
            // ...
            // Start login on another thread
            var loginTask = Task<string[]>.Run(() => cm.login(strLogin, pass));
            // Create task that is used to wake-up main thread, when user clicks
            // on the Cancel button before login finishes.
            CancelLoginTcs = new TaskCompletionSource<Object>();
            // Wait for login task or cancel task to complete, whichever finishes first
            await Task.WhenAny(loginTask, CancelLoginTcs.Task);
            if (CancelLoginTcs.Task.IsCanceled)
            {
                // User clicked on the Cancel button.
                // Login method will be running in the background, until it
                // finishes. This assumes that it is safe to do so.
                // Here you should do neccessary clean-up, inform user, etc.
                // ...
            }
            else
            {
                // Login finished and user did NOT click on the Cancel button.
                try
                {
                    // Simply read result of login. If an Exception occured during login,
                    // it will be rethrow now, so you should handle it appropriatelly
                    var user = loginTask.Result;
                    // Here program continues in a usual way
                    // ...
                }
                catch(Exception E)
                {
                    // Handle login exception
                    // ...
                }
            }
        }
        finally
        {
            // Hide Cancel button again
            btnCancel.Visible = false;
            CancelLoginTcs = null;
        }
    }
    private void btnCancel_Click(object sender, EventArgs e)
    {
        // Set cancel task to cancelled state. 
        // This will wake-up main thread and let it continue
        CancelLoginTcs.SetCanceled();
    }
