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
                        var t1 = RunMethodAsync(param1, param1, group);
                        var t2 = RunMethodAsync(param1, param2, group);
                        var t3 = RunMethodAsync(param1, param3, group);
                        await Task.WhenAll(t1, t2, t3);
                        break;
                    }
                case (2):
                    {
                        var t1 = RunMethodAsync(param2, param1, group);
                        var t2 = RunMethodAsync(param2, param2, group);
                        var t3 = RunMethodAsync(param2, param3, group);
                        await Task.WhenAll(t1, t2, t3);
                        break;
                    }
            }
        }
        async Task RunMethodAsync(string var1, string var2, int varGroup)
        {
            ////////////////////////////////////////////
            // Use ProcessStartInfo class
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = false;
            startInfo.FileName = "SomeOutsideEXE";
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.Arguments = var1 + " " + var2 + " " + varGroup;
            using (Process exeProcess = new Process())
            {
                var cts = new TaskCompletionSource<int>();
                exeProcess.StartInfo = startInfo;
                exeProcess.EnableRaisingEvents = true;
                exeProcess.Exited += (sender, e) => cts.SetResult(exeProcess.ExitCode);
                exeProcess.Start();
                var exitCode = await cts.Task;
            }
        }
