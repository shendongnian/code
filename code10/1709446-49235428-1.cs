    // Change a pixel.
    lastCommand = new ChangePixelCommand(myImage, 
                                         Control.MousePosition.X,
                                         Control.MousePosition.Y, 
                                         Colors.Red);
    lastCommand.Execute();
    
    // Undo the change
    lastCommand.Undo();
