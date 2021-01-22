    Command(CommandNames.File)
      .Is<DummyCommand>()
      .AlwaysEnabled();
    Command(CommandNames.FileNew)
      .Bind(Shortcut.CtrlN)
      .Is<FileNewCommand>()
      .Enable(WorkspaceStatusProviderNames.DocumentFactoryRegistered);
    Command(CommandNames.FileSave)
      .Bind(Shortcut.CtrlS)
      .Enable(WorkspaceStatusProviderNames.DocumentOpen)
      .Is<FileSaveCommand>();
    Command(CommandNames.FileSaveAs)
      .Bind(Shortcut.CtrlShiftS)
      .Enable(WorkspaceStatusProviderNames.DocumentOpen)
      .Is<FileSaveAsCommand>();
            
    Command(CommandNames.FileOpen)
      .Is<FileOpenCommand>()
      .Enable(WorkspaceStatusProviderNames.DocumentFactoryRegistered);
            
    Command(CommandNames.FileOpenFile)
      .Bind(Shortcut.CtrlO)
      .Is<FileOpenFileCommand>()
      .Enable(WorkspaceStatusProviderNames.DocumentFactoryRegistered);
    Command(CommandNames.FileOpenRecord)
      .Bind(Shortcut.CtrlShiftO)
      .Is<FileOpenRecordCommand>()
      .Enable(WorkspaceStatusProviderNames.DocumentFactoryRegistered);
