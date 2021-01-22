     PrintingSystemCommand[] commands = {PrintingSystemCommand.DocumentMap,
                                                       PrintingSystemCommand.Open,
                                                       PrintingSystemCommand.Save};
    
     this.printControl1.PrintingSystem.SetCommandVisibility(commands, CommandVisibility.None);
    
