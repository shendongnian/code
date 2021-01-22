    class EcuData
        {
            public int RPM { get; set; }
            public int MAP { get; set; }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            EcuData data = new EcuData
            {
                RPM = 0,
                MAP = 0
            };
            BackWorker1.RunWorkerAsync(data);
        }
        private void BackWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            EcuData argumentData = e.Argument as EcuData;
            int x = 0;
            while (x<=10)
            {
                e.Result = argumentData;
                Thread.Sleep(100);
                this.Invoke((MethodInvoker)delegate
                {
                    label1.Text = Convert.ToString(argumentData.RPM = x);           //send hardware data later instead, x is for testing only!
                    label2.Text = Convert.ToString(argumentData.MAP = x * 2);       //send hardware data later instead, x is for testing only!
                });
                x++;
           }
        }
