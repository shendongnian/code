    public class frm_Save : Form
    {
    	public FrmProgress(List<TransferOptions> transferOptions)
    	{
    		InitializeComponent();
    		BackgroundWorker BgrdWorker = new System.ComponentModel.BackgroundWorker();
    		this.BgrdWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BgrdWorker_DoWork);
    		this.BgrdWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BgrdWorker_RunWorkerCompleted);
    	}
    	
    	private void FrmProgress_Load(object sender, EventArgs e)
    	{
    		// Show image and message...
    	}
    	
    	private void BgrdWorker_DoWork(object sender, DoWorkEventArgs e)
    	{
    		// Call your video Process start Function
    		// after that
    		var stopWatch = new StopWatch();
    		stopWatch.Start()
    		while (true)
    		{
    			if (stopWatch.ElapsedMilliseconds >1000 || videoProcessHasReturnedSuccessfully)
    			{
    				break
    			}
    		}
    	}
    	
    	private void BgrdWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    	{
    		// inform the user the video processing is finished
    		this.Close();
    	}
    }
