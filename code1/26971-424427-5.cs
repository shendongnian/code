    // This should all be refactored to make it less tightly-coupled, obviously.
    public static void Main(string args[])
    {
      // Process the args.
      <process args here>
      // Create the application base.
      MyWindowsApplicationBase appBase = new MyWindowsApplicationBase();
      // <1> Set the StartupNextInstance event handler.
      appBase.StartupNextInstance = <event handler code>;
      // Show the main form of the app.
      appBase.Run(args);
    }
