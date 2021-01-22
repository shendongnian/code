    My.Application.Info.DirectoryPath
      AppDomain.CurrentDomain.BaseDirectory
    
    My.Computer.Clipboard
      System.Windows.Clipboard //(WPF)
      System.Windows.Forms.Clipboard //(WinForms)
    
    My.Computer.Audio.PlaySystemSound()
      System.Media.SystemSounds.*.Play()
    
    My.Application.Shutdown()
      System.Windows.Forms.Application.Exit() //(WinForms)
      or
      System.Windows.Application.Current.Shutdown()  //(WPF)
      or
      System.Environment.Exit(ExitCode)  //(Both WinForms & WPF)
