    <%@ Page Language="C#" %>
    
    <!DOCTYPE html>
    
    <script runat="server">
    
        protected void btnRun_Click(object sender, EventArgs e)
        {
            var jobState = new StateInfo()
            {
                Id = 1,
                Counter = 0,
                Content = "Start the job",
                Cancelled = false,
                Completed = false
            };
            Session["job"] = jobState; //Save state between requests
            System.Threading.ThreadPool.QueueUserWorkItem(
                new System.Threading.WaitCallback(LongJob),
                jobState
                );//returns immediately
            lblState.Text += "<br />" + jobState.Counter.ToString() 
                + " Completed: " + jobState.Completed.ToString()
                + " Cancelled: " + jobState.Cancelled.ToString()
                + "<br />" + jobState.Content;
            btnCancel.Visible = true;
            btnCheck.Visible = true;
        }
    
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            var jobState = Session["job"] as StateInfo;
            if (!jobState.Completed)
                jobState.Cancelled = true;
            System.Threading.Thread.Sleep(1000);//wait for the next loop to complete
            lblState.Text += "<br />" + jobState.Counter.ToString()
                + " Completed: " + jobState.Completed.ToString()
                + " Cancelled: " + jobState.Cancelled.ToString()
                + (jobState.Completed || jobState.Cancelled ? "<br />" + jobState.Content : "");
        }
    
        protected void btnCheck_Click(object sender, EventArgs e)
        {
            var jobState = Session["job"] as StateInfo;
            lblState.Text += "<br />" + jobState.Counter.ToString()
                + " Completed: " + jobState.Completed.ToString()
                + " Cancelled: " + jobState.Cancelled.ToString()
                + (jobState.Completed || jobState.Cancelled ? "<br />" + jobState.Content : "");
        }
    
        private void LongJob(object state)
        {
            var jobState = state as StateInfo;
            do
            {
                System.Threading.Thread.Sleep(1000);
                jobState.Counter++;
                if (jobState.Counter >= 100)
                {
                    jobState.Completed = true;
                    jobState.Content = "The job is completed";
                }
                else if (jobState.Cancelled)
                    jobState.Content = "The job is cancelled";
            }
            while (!jobState.Cancelled && !jobState.Completed);
        }
        [Serializable]
        class StateInfo
        {
            public int Id { get; set; }
            public int Counter { get; set; }
            public string Content { get; set; }
            public bool Cancelled { get; set; }
            public bool Completed { get; set; }
        }
    
    </script>
    
    <html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>Long Job</title>
    </head>
    <body>
        <form id="form1" runat="server">
            <div>
                <asp:Label ID="lblState" runat="server"></asp:Label><br />
                <asp:Button runat="server" ID="btnRun" OnClick="btnRun_Click" Text="Run" />
                <asp:Button runat="server" ID="btnCheck" OnClick="btnCheck_Click" Text="Check State" Visible="false" />
                <asp:Button runat="server" ID="btnCancel" OnClick="btnCancel_Click" Text="Cancel" Visible="false" />
            </div>
        </form>
    </body>
    </html>
