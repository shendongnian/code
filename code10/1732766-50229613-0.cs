            Boolean closeme = false;
            using (System.Diagnostics.Process updater = new System.Diagnostics.Process())
            {
                updater.StartInfo.FileName = "B.exe";
                if (updater.Start())
                    while (!updater.HasExited)
                    {
                        if (updater.Responding)
                        {
                            closeme = true;
                            break;
                        }
                        /* insert a timeout if process hangs */
                    }
                if (updater.HasExited)
                {
                    /* Do something else (updater.ExitCode)  */
                }
               
            }
            if (closeme)
                this.Close();
