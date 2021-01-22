    public class Form1
    {
    
    	int totalHits = 0;
    
    	public object getCPUCounter()
    	{
    
    		PerformanceCounter cpuCounter = new PerformanceCounter();
    		cpuCounter.CategoryName = "Processor";
    		cpuCounter.CounterName = "% Processor Time";
    		cpuCounter.InstanceName = "_Total";
    
                         // will always start at 0
    		dynamic firstValue = cpuCounter.NextValue();
    		System.Threading.Thread.Sleep(1000);
                        // now matches task manager reading
    		dynamic secondValue = cpuCounter.NextValue();
    		
    		return secondValue;
    
    	}
    
    
    	private void Timer1_Tick(Object sender, EventArgs e)
    	{
    		int cpuPercent = getCPUCounter();
    		if (cpuPercent >= 90) {
    			totalHits = totalHits + 1;
    			if (totalHits == 60)
    				Interaction.MsgBox("ALERT 90% usage for 1 minute");
    			totalHits = 0;
                        
    		} else {
    			totalHits = 0;
    		}
    
    		Label1.Text = cpuPercent + " % CPU";
    		Label2.Text = getRAMCounter() + " RAM Free";
    		Label3.Text = totalHits + " seconds over 20% usage";
    
    	}
    }
