    MenuBarController mb;
    // ...
    mb.Add(Resources.FileMenu, x =>
    {
      x.Executes(CommandNames.File);
      x.Menu
        .AddButton(Resources.FileNewCommandImage, Resources.FileNew, Resources.FileNewTip, y => y.Executes(CommandNames.FileNew))
        .AddButton(null, Resources.FileOpen, Resources.FileOpenTip, y => 
        {
          y.Executes(CommandNames.FileOpen);
          y.Menu
            .AddButton(Resources.FileOpenFileCommandImage, Resources.OpenFromFile, Resources.OpenFromFileTop, z => z.Executes(CommandNames.FileOpenFile))
            .AddButton(Resources.FileOpenRecordCommandImage, Resources.OpenRecord, Resources.OpenRecordTip, z => z.Executes(CommandNames.FileOpenRecord));
         })
         .AddSeperator()
         .AddButton(null, Resources.FileClose, Resources.FileCloseTip, y => y.Executes(CommandNames.FileClose))
         .AddSeperator();
         // ...
    });
