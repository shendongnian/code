    _applicationObject = (DTE2)application;
    _addInInstance = (AddIn)addInInst;
    if (connectMode == ext_ConnectMode.ext_cm_UISetup)
    {
        object[] contextGUIDS = new object[] { };
        Commands2 commands = (Commands2)_applicationObject.Commands;
        CommandBars commandBars = (CommandBars)_applicationObject.CommandBars;
        CommandBar menuBarCommandBar = commandBars["MenuBar"];
        CommandBarPopup filePopup = menuBarCommandBar.Controls["File"] as CommandBarPopup;
        CommandBarPopup newPopup = filePopup.CommandBar.Controls["New"] as CommandBarPopup;
        Command command = commands.AddNamedCommand2(_addInInstance, "MyAddin1", "MyAddin1", 
            "Executes the command for MyAddin1", true, 59, ref contextGUIDS, 
            (int)(vsCommandStatus.vsCommandStatusSupported | vsCommandStatus.vsCommandStatusEnabled),
            (int)vsCommandStyle.vsCommandStylePictAndText, vsCommandControlType.vsCommandControlTypeButton);
        if (command == null || newPopup == null)
        {
            command.AddControl(newPopup.CommandBar, 1);
        }
    }
