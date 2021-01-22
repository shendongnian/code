        ///--------------------------------------------------------------------------------
        /// <summary>This method implements the OnConnection method of the IDTExtensibility2 interface. Receives notification that the Add-in is being loaded.</summary>
        ///
        /// <param term='application'>Root object of the host application.</param>
        /// <param term='connectMode'>Describes how the Add-in is being loaded.</param>
        /// <param term='addInInst'>Object representing this Add-in.</param>
        /// <seealso class='IDTExtensibility2' />
        ///--------------------------------------------------------------------------------
        public void OnConnection(object application, ext_ConnectMode connectMode, object addInInst, ref Array custom)
        {
            _applicationObject = (DTE2)application;
            _addInInstance = (AddIn)addInInst;
            // Get the solution command bar
            CommandBar solutionCommandBar = ((CommandBars)_applicationObject.CommandBars)["Solution"];
            // Set up the main InCode
            CommandBarPopup solutionPopup = (CommandBarPopup)solutionCommandBar.Controls.Add(MsoControlType.msoControlPopup, System.Reflection.Missing.Value, System.Reflection.Missing.Value, 1, true);
            solutionPopup.Caption = "InCode";
            // Add solution updater submenu
            CommandBarControl solutionUpdaterControl = solutionPopup.Controls.Add(MsoControlType.msoControlButton, System.Reflection.Missing.Value, System.Reflection.Missing.Value, 1, true);
            solutionUpdaterControl.Caption = "Update Solution";
            updateSolutionMenuItemHandler = (CommandBarEvents)_applicationObject.Events.get_CommandBarEvents(solutionUpdaterControl);
            updateSolutionMenuItemHandler.Click += new _dispCommandBarControlEvents_ClickEventHandler(updateSolution_Click);
        }
        // The event handlers for the solution submenu items
        CommandBarEvents updateSolutionMenuItemHandler;
        ///--------------------------------------------------------------------------------
        /// <summary>This property gets the solution updater output pane.</summary>
        ///--------------------------------------------------------------------------------
        protected OutputWindowPane _solutionUpdaterPane = null;
        protected OutputWindowPane SolutionUpdaterPane
        {
            get
            {
                if (_solutionUpdaterPane == null)
                {
                    OutputWindow outputWindow = _applicationObject.ToolWindows.OutputWindow;
                    foreach (OutputWindowPane loopPane in outputWindow.OutputWindowPanes)
                    {
                        if (loopPane.Name == "Solution Updater")
                        {
                            _solutionUpdaterPane = loopPane;
                            return _solutionUpdaterPane;
                        }
                    }
                    _solutionUpdaterPane = outputWindow.OutputWindowPanes.Add("Solution Updater");
                }
                return _solutionUpdaterPane;
            }
        }
        ///--------------------------------------------------------------------------------
        /// <summary>This method handles clicking on the Update Solution submenu.</summary>
        ///
        /// <param term='inputCommandBarControl'>The control that is source of the click.</param>
        /// <param term='handled'>Handled flag.</param>
        /// <param term='cancelDefault'>Cancel default flag.</param>
        ///--------------------------------------------------------------------------------
        protected void updateSolution_Click(object inputCommandBarControl, ref bool handled, ref bool cancelDefault)
        {
            try
            {
                // set up and execute solution updater thread
                UpdateSolutionDelegate updateSolutionDelegate = UpdateSolution;
                updateSolutionDelegate.BeginInvoke(UpdateSolutionCompleted, updateSolutionDelegate);
            }
            catch (System.Exception ex)
            {
                // put exception message in output pane
                SolutionUpdaterPane.OutputString(ex.Message);
            }
        }
        protected delegate void UpdateSolutionDelegate();
        ///--------------------------------------------------------------------------------
        /// <summary>This method launches the solution updater to update the solution.</summary>
        ///--------------------------------------------------------------------------------
        protected void UpdateSolution()
        {
            try
            {
                // set up solution updater process
                string solutionDir = System.IO.Path.GetDirectoryName(_applicationObject.Solution.FullName);
                System.Diagnostics.ProcessStartInfo procStartInfo = new System.Diagnostics.ProcessStartInfo(@"SolutionUpdater.exe", solutionDir);
                procStartInfo.RedirectStandardOutput = true;
                procStartInfo.UseShellExecute = false;
                procStartInfo.CreateNoWindow = true;
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo = procStartInfo;
                // execute the solution updater
                proc.Start();
                // put solution updater output to output pane
                SolutionUpdaterPane.OutputString(proc.StandardOutput.ReadToEnd());
                SolutionUpdaterPane.OutputString("Solution update complete.");
            }
            catch (System.Exception ex)
            {
                // put exception message in output pane
                SolutionUpdaterPane.OutputString(ex.Message);
            }
        }
        ///--------------------------------------------------------------------------------
        /// <summary>This method completing the update solution thread.</summary>
        ///
        /// <param name="ar">IAsyncResult.</param>
        ///--------------------------------------------------------------------------------
        protected void UpdateSolutionCompleted(IAsyncResult ar)
        {
            try
            {
                if (ar == null) throw new ArgumentNullException("ar");
                UpdateSolutionDelegate updateSolutionDelegate = ar.AsyncState as UpdateSolutionDelegate;
                Trace.Assert(updateSolutionDelegate != null, "Invalid object type");
                updateSolutionDelegate.EndInvoke(ar);
            }
            catch (System.Exception ex)
            {
                // put exception message in output pane
                SolutionUpdaterPane.OutputString(ex.Message);
            }
        }
