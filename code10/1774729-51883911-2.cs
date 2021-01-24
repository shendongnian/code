       public partial class Alerts : Form
       {
          #region Private Fields
    
          private static BackgroundWorker bgw = new BackgroundWorker();
          private int _period = 5000;
          private System.Threading.Timer _timerThread;
    
          #endregion Private Fields
    
          #region Public Constructors
    
          public Alerts()
          {
             InitializeComponent();
             bgw.DoWork += bgw_DoWork;
             bgw.RunWorkerCompleted += bgw_RunWorkerCompleted;
    
             _timerThread = new System.Threading.Timer((o) =>
             {
                // Stop the timer;
                _timerThread.Change(-1, -1);
                // Calls UpdateAlerts() that updates a datagridview with the mysql data
                
                bgw.RunWorkerAsync();
    
                // start timer again (BeginTime, Interval)
                _timerThread.Change(_period, _period);
             }, null, 0, _period);
          }
    
          #endregion Public Constructors
    
          #region Private Methods
    
          private void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
          {
                  DataGridView1.Invoke(new System.Action(() => 
        {DataGridView1.DataSource = e.Result;}));
          }
    
          private void bgw_DoWork(object sender, DoWorkEventArgs e)
          {
             string constring = "datasource=localhost;port=3306;username=root;password=******";
             MySqlConnection conDataBase = new MySqlConnection(constring);
             MySqlCommand cmdDataBase = new MySqlCommand(" select * from shopmanager.alerts ;", conDataBase);
    
             try
             {
                conDataBase.Open();
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmdDataBase;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bsource = new BindingSource();
    
                bsource.DataSource = dbdataset;
                sda.Update(dbdataset);
                e.Result = dbdataset;
             }
             catch (Exception ex)
             {
                MessageBox.Show(ex.Message);
             }
             conDataBase.Close();
          }
    
          #endregion Private Methods
       }
