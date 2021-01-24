    private void CallToChildThread()
    {
        Program.stateOld = controller.GetState();
        while (controller.IsConnected)
        {
            // Your update logic
            Thread.Sleep(10); // Adjust the delay as needed
        }
    }
