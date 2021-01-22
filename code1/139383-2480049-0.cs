    private void btnMyExit_Click(object sender, EventArgs e)
    {
        // TODO: add any special logic you want to execute when they click your own "Exit" button
        doCustomExitWork();
    }
    
    public static void OnAppExit(object sender, EventArgs e)
    {
        doCustomExitWork();
    }
    private void doCustomExitWork()
    {
        // TODO: add any logic you want to always do when exiting the app, omit this whole method if you don't need it
    }
