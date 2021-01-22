    using System;
    using Excel = Microsoft.Office.Interop.Excel;
    namespace Helpers.Vsto
    {
        public sealed class WorkbookClosedMonitor
        {
            internal class CloseRequestInfo
            {
                public CloseRequestInfo(string name, int count)
                {
                    this.WorkbookName = name;
                    this.WorkbookCount = count;
                }
                public string WorkbookName { get; set; }
                public int WorkbookCount { get; set; }
            }
            public WorkbookClosedMonitor(Excel.Application application)
            {
                if (application == null)
                {
                    throw new ArgumentNullException("application");
                }
                this.Application = application;
                this.Application.WorkbookActivate += Application_WorkbookActivate;
                this.Application.WorkbookBeforeClose += Application_WorkbookBeforeClose;
                this.Application.WorkbookDeactivate += Application_WorkbookDeactivate;
            }
            public event EventHandler<WorkbookClosedEventArgs> WorkbookClosed;
            public Excel.Application Application { get; private set; }
            private CloseRequestInfo PendingRequest { get; set; }
            private void Application_WorkbookDeactivate(Excel.Workbook wb)
            {
                if (this.Application.Workbooks.Count == 1)
                {
                    // With only one workbook available deactivating means it will be closed
                    this.PendingRequest = null;
                    this.OnWorkbookClosed(new WorkbookClosedEventArgs(wb.Name));
                }
            }
            private void Application_WorkbookBeforeClose(Excel.Workbook wb, ref bool cancel)
            {
                if (!cancel)
                {
                    this.PendingRequest = new CloseRequestInfo(
                        wb.Name, 
                        this.Application.Workbooks.Count);
                }
            }
            private void Application_WorkbookActivate(Excel.Workbook wb)
            {
                // A workbook was closed if a request is pending and the workbook count decreased
                bool wasWorkbookClosed = true
                    && this.PendingRequest != null
                    && this.Application.Workbooks.Count < this.PendingRequest.WorkbookCount;
                if (wasWorkbookClosed)
                {
                    var args = new WorkbookClosedEventArgs(this.PendingRequest.WorkbookName);
                    this.PendingRequest = null;
                    this.OnWorkbookClosed(args);
                }
                else
                {
                    this.PendingRequest = null;
                }
            }
            private void OnWorkbookClosed(WorkbookClosedEventArgs e)
            {
                var handler = this.WorkbookClosed;
                if (handler != null)
                {
                    handler(this, e);
                }
            }
        }
        public sealed class WorkbookClosedEventArgs : EventArgs
        {
            internal WorkbookClosedEventArgs(string name)
            {
                this.Name = name;
            }
            public string Name { get; private set; }
        }
    }
