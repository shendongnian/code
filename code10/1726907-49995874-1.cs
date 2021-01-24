        private TaskWaterMark taskPaneControl1;
        private Microsoft.Office.Tools.CustomTaskPane taskPaneValue;
       
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            taskPaneControl1 = new TaskWaterMark();
            taskPaneValue = this.CustomTaskPanes.Add(taskPaneControl1, "MyCustomTaskPane");
            taskPaneValue.Visible = true;
            //taskPaneValue.DockPosition = Office.MsoCTPDockPosition.msoCTPDockPositionFloating;
            //taskPaneValue.Height = 500;
            //taskPaneValue.Width = 500;
            //taskPaneValue.DockPosition = Office.MsoCTPDockPosition.msoCTPDockPositionRight;
            //taskPaneValue.Width = 300;
            this.Application.WorkbookActivate += new Excel.AppEvents_WorkbookActivateEventHandler(Application_WorkbookActivate);
            taskPaneValue.VisibleChanged +=new EventHandler(taskPaneValue_VisibleChanged);
        }
        private void Application_WorkbookActivate(Microsoft.Office.Interop.Excel.Workbook wb)
        {
        }
        public void taskPaneValue_VisibleChanged(object sender, System.EventArgs e)
        {
            Globals.Ribbons.Ribbon1.toggleButton2.Checked = taskPaneValue.Visible;
        }
        public Microsoft.Office.Tools.CustomTaskPane TaskPane
        {
            get { return taskPaneValue;}
        }
