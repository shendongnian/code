    var frame = new DispatcherFrame();
    CustomMessageBox b = new CustomMessageBox("hello world");
    c.DialogClosed += ()=>
    {
        frame.Continue = false; // stops the frame
    }
    // this raises an event listened for by the main window view model,
    // displaying the message box and greying out the rest of the program.
    base.ShowMessageBox(b);
    
    // This will "block" execution of the current dispatcher frame
    // and run our frame until the dialog is closed.
    Dispatcher.PushFrame(frame);
