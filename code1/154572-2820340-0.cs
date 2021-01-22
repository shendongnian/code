    private void InitializeComponent()
    {
        this.timer1 = new System.Timers.Timer();
        ((System.ComponentModel.ISupportInitialize)(this.timer1)).BeginInit();
        // 
        // timer1
        // 
        
        this.timer1.Elapsed += new System.Timers.ElapsedEventHandler(this.timer1_Elapsed);
        // 
        // DataSyncService
        // 
        this.ServiceName = "DataSyncService";
        this.CanShutdown = true;
        ((System.ComponentModel.ISupportInitialize)(this.timer1)).EndInit();
    }
