            listBox1.Items.Clear();
            Process pc = Process.GetProcessesByName("winrar")[0];
            ProcessModuleCollection pmc = pc.Modules;
            foreach(ProcessModule pm2 in pmc)
            {
                listBox1.Items.Add(pm2.ModuleName + "!" + pm2.BaseAddress);
            }
