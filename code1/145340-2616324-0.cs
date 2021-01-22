    // Transform rect2 to device coordinates
    rect2.Transform(PresentationSource.FromVisual(window).TransformToDevice);
    // Execute the rest of this in a separate thread
    ThreadPool.QueueUserWorkItem(_ =>
    {
      // Start Word
      var process = Process.Create(pathToWinwordExe);
      // Wait for Word to initialize
      process.WaitForInputIdle();
      // Set the position of the main window
      IntPtr hWnd = process.MainWindowHandle;
      if(hWnd!=IntPtr.Zero)
        SetWindowPos(
          hWnd, IntPtr.Zero,
          (int)rect2.X, (int)rect2.Y, (int)rect2.Width, (int)rect2.Height,
          SWP_NOZORDER);
    });
