      _applicationObject = (DTE2)application;
            _addInInstance = (AddIn)addInInst;
            if (connectMode == ext_ConnectMode.ext_cm_UISetup)
            {
                object[] contextGUIDS = new object[] { };
                Commands2 commands = (Commands2)_applicationObject.Commands;
                string toolsMenuName = "Tools";
                //Place the command on the tools menu.
                //Find the MenuBar command bar, which is the top-level command bar holding all the main menu items:
                Microsoft.VisualStudio.CommandBars.CommandBar menuBarCommandBar = ((Microsoft.VisualStudio.CommandBars.CommandBars)_applicationObject.CommandBars)["MenuBar"];
                //Find the Tools command bar on the MenuBar command bar:
                CommandBarControl toolsControl = menuBarCommandBar.Controls[toolsMenuName];
                CommandBarPopup toolsPopup = (CommandBarPopup)toolsControl;
                // get popUp command bars where commands will be registered.
                CommandBars cmdBars = (CommandBars)(_applicationObject.CommandBars);
                CommandBar vsBarItem = cmdBars["Item"]; //the pop up for clicking a project Item
                CommandBar vsBarWebItem = cmdBars["Web Item"];
                CommandBar vsBarMultiItem = cmdBars["Cross Project Multi Item"];
                CommandBar vsBarFolder = cmdBars["Folder"];
                CommandBar vsBarWebFolder = cmdBars["Web Folder"];
                CommandBar vsBarProject = cmdBars["Project"]; //the popUpMenu for right clicking a project
                CommandBar vsBarProjectNode = cmdBars["Project Node"];
                //This try/catch block can be duplicated if you wish to add multiple commands to be handled by your Add-in,
                //  just make sure you also update the QueryStatus/Exec method to include the new command names.
                try
                {
                    //Add a command to the Commands collection:
                    Command command = commands.AddNamedCommand2(_addInInstance, "HintPaths", "HintPaths", "Executes the command for HintPaths", true, 59, ref contextGUIDS, (int)vsCommandStatus.vsCommandStatusSupported + (int)vsCommandStatus.vsCommandStatusEnabled, (int)vsCommandStyle.vsCommandStylePictAndText, vsCommandControlType.vsCommandControlTypeButton);
                    //Add a control for the command to the tools menu:
                    if ((command != null) && (toolsPopup != null))
                    {
                        //command.AddControl(toolsPopup.CommandBar, 1);
                        command.AddControl(vsBarProject); 
                    }
                }
                catch (System.ArgumentException argEx)
                {
                    System.Diagnostics.Debug.Write("Exception in HintPaths:" + argEx.ToString());
                    //If we are here, then the exception is probably because a command with that name
                    //  already exists. If so there is no need to recreate the command and we can 
                    //  safely ignore the exception.
                }
            }
        }
