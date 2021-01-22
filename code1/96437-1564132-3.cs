        //you will setup "Updater" in some else way. I've written this function
        //which I call on a button click for testing
        private void Init()
        {
            var u = new Updater();
            u.DataReceived += delegate(object sender, DataEventArgs e) 
                                    { SetTextboxText(e.Data); };
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += delegate(object sender, DoWorkEventArgs e) 
                    { ((Updater)e.Argument).ReadData(); };
            bw.RunWorkerAsync(u);
        }
        private void SetTextboxText(string s)
        {
            if (TEXT_BOX.InvokeRequired)
            {
                //This techniques is from answer by @sinperX1
                BeginInvoke((MethodInvoker)(() => { SetTextboxText(s); }));
                return;
            }
            TEXT_BOX.Text += Environment.NewLine + s;
        }   
