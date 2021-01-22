    PerformanceCounter ProcessCPUCounter = new PerformanceCounter();
                ProcessCPUCounter.CategoryName = "Process";
                ProcessCPUCounter.CounterName = "% Processor Time";
                ProcessCPUCounter.InstanceName = "TestServiceName"; 
                ProcessCPUCounter.ReadOnly = true;
    
    t3 = new Timer();
                t3.Tick += new EventHandler(ProcessCPUThread); // Everytime t3 ticks, th2_Tick will be called
                t3.Interval = (1000) * (1);              // Timer will tick evert second
                t3.Enabled = true;                       // Enable the t3
                t3.Start(); 
    
    private void ProcessCPUThread(object sender, EventArgs e)
            {
                try
                {         
                    Int32 processCPU = Convert.ToInt32( ProcessCPUCounter.NextValue());
    
                    tbCPUperPrcocess.Text = Convert.ToString(processCPU / Environment.ProcessorCount);
                }
                catch (Exception ex)
                {
                    
                    MessageBox.Show(ex.Message.ToString());
                }
            }
