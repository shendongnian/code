    public class Form1 : Form
    {
        // C0nstructor and stuff
        ....
    	// Instance of a Counter
    	PerformanceCounter performance = new PersormanceCounter("Processor", "% Processor Time(Usage)", "_Total");
    	
    	// Ticking timer each X ms
    	private void timer1_onTick(object sender, EventArgs e) 
    	{
    		label1.Text = "CPU-Usage: " + getCpuUsage();
    	}
    	
    	// Getting the CPU-Usage value with symbol
    	private String getCpuUsagePercent()
    	{
    		return performance.NextValue() + " %";
    	}
    }
