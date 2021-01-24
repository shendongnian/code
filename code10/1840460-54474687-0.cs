    public partial class frm_Save : Form
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
            // let the BgrdWorker start:
            this.BgrdWorker.RunWorkerAsync();
    	}
    	
    	private void BgrdWorker_DoWork(object sender, DoWorkEventArgs e)
    	{
    		// Do your video processing task here
    	}
    	
    	private void BgrdWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    	{
    		// inform the user the video processing is finished
    		this.Close();
    	}
    }
