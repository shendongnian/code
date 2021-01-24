        private async void button1_Click(object sender, EventArgs e)
        {
            await RunSomeTasks(1);
            lblStatus.Text = "done!";
        }
        public async Task RunSomeTasks(int group)
        {
            switch (group)
            {
                case (1):
                    {
                        var t1 = Task.Run(() => RunAsyncMethod(param1, param1, group));
                        var t2 = Task.Run(() => RunAsyncMethod(param1, param2, group));
                        var t3 = Task.Run(() => RunAsyncMethod(param1, param3, group));
                        await Task.WhenAll(t1, t2, t3);
                        break;
                    }
                case (2):
                    {
                        var t1 = Task.Run(() => RunAsyncMethod(param2, param1, group));
                        var t2 = Task.Run(() => RunAsyncMethod(param2, param2, group));
                        var t3 = Task.Run(() => RunAsyncMethod(param2, param3, group));
                        await Task.WhenAll(t1, t2, t3);
                        break;
                    }
            }
        }
        void RunAsyncMethod(string var1, string var2, int varGroup)
        {
            ////////////////////////////////////////////
            // Use ProcessStartInfo class
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = false;
            startInfo.FileName = "SomeOutsideEXE";
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.Arguments = var1 + " " + var2 + " " + varGroup;
            using (Process exeProcess = Process.Start(startInfo))
            {
                // did not work -> Task.Run(() => exeProcess.WaitForExit()).Wait();
                exeProcess.WaitForExit();
            }
        }
