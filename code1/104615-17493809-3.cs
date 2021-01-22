        Thread th= new Thread(() =>
        {
                for (int i = 0; i < processes.Count; i++)
                {
                        processes[i].Start();
                        processes[i].WaitForExit();
                 }
        });
        th.Start();
