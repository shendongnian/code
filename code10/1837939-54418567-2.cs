    private async Task<StorageLibrary> TryAccessLibraryAsync(KnownLibraryId library)
    {
        try
        {
            return await StorageLibrary.GetLibraryAsync(library);
        }
        catch (UnauthorizedAccessException)
        {
            //inform user about missing permission and ask to grant it
            MessageDialog requestPermissionDialog =
                new MessageDialog($"The app needs to access the {library}. " +
                           "Press OK to open system settings and give this app permission. " +
                           "If the app closes, please reopen it afterwards. " +
                           "If you Cancel, the app will have limited functionality only.");
            var okCommand = new UICommand("OK");
            requestPermissionDialog.Commands.Add(okCommand);
            var cancelCommand = new UICommand("Cancel");
            requestPermissionDialog.Commands.Add(cancelCommand);
            requestPermissionDialog.DefaultCommandIndex = 0;
            requestPermissionDialog.CancelCommandIndex = 1;
    
            var requestPermissionResult = await requestPermissionDialog.ShowAsync();
            if (requestPermissionResult == cancelCommand)
            {
                //user chose to Cancel, app will not have permission
                return null;
            }
    
            //open app settings to allow users to give us permission
            await Launcher.LaunchUriAsync(new Uri("ms-settings:appsfeatures-app"));
    
            //confirmation dialog to retry
            var confirmationDialog = new MessageDialog(
                  $"Please give this app the {library} permission.");
            confirmationDialog.Commands.Add(okCommand);
            await confirmationDialog.ShowAsync();
    
            //retry
            return await TryAccessLibraryAsync(library);
        }
    }
