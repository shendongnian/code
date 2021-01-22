            internal static void SyncNow()
            {
                CreateWorker(new MergeRepl(SystemInformation.ComputerName + "\\SQLEXPRESS", "WWCSTAGE", "aspnetdb", "aspnetdb", "aspnetdb"));
                //etc...
            }
            private static void CreateWorker(MergeRepl repl)
            {
                BackgroundWorker connect = new BackgroundWorker { WorkerReportsProgress = false, WorkerSupportsCancellation = true };
                connect.DoWork += new DoWorkEventHandler(DoWork);
                
                if (connect.IsBusy != true)
                    connect.RunWorkerAsync(repl);
            }
            private static void DoWork(object sender, DoWorkEventArgs e) 
            { 
                BackgroundWorker worker = sender as BackgroundWorker; 
                try 
                { 
                    MergeRepl aspnetdbMergeRepl = e.Argument as MergeRepl;
                    aspnetdbMergeRepl.RunDataSync(); 
                    areAllInSync += 1; 
                } 
                catch (Exception) 
                { 
                    if (worker != null) worker.CancelAsync(); 
                } 
            }
