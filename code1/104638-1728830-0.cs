    namespace SMSPicker
    {
     public partial class SMSPicker : ServiceBase{
        SendSMS smsClass;
        AutoResetEvent autoEvent;
        TimerCallback timerCallBack;
        Timer timerThread;
        public SMSPicker()
        {
            InitializeComponent();
        }
        protected override void OnStart(string[] args)
        {
            // TODO: Add code here to start your service.
            smsClass = new SendSMS();
            autoEvent = new AutoResetEvent(false);
            long timePeriod = string.IsNullOrEmpty(ConfigurationSettings.AppSettings["timerDuration"]) ? 10000 : Convert.ToInt64(ConfigurationSettings.AppSettings["timerDuration"]);
            timerCallBack = new TimerCallback(sendSMS);
            timerThread = new Timer(timerCallBack, autoEvent, 0, timePeriod);
        }
        private void sendSMS(object stateInfo)
        {
            AutoResetEvent autoResetEvent = (AutoResetEvent)stateInfo;
            smsClass.startSendingMessage();
            autoResetEvent.Set();
         }
        protected override void OnStop()
        {
            // TODO: Add code here to perform any tear-down necessary to stop your service.
            smsClass.stopSendingMessage();
            timerThread.Dispose();            
            
        }
    }
    }
    namespace SMSPicker
    {
	class SendSMS
    {
		//This variable has been done in order to ensure that other thread does not work till this thread ends
        bool taskDone = true;
		public SendSMS()
        {
        }
        //this method will start sending the messages by hitting the database
        public void startSendingMessage()
        {
            if (!taskDone)
            {
                writeToLog("A Thread was already working on the same Priority.");
                return;
            }
            try
            {
            }
            catch (Exception ex)
            {
                writeToLog(ex.Message);
            }
            finally
            {
                taskDone = stopSendingMessage();
                //this will ensure that till the database update is not fine till then, it will not leave trying to update the DB
                while (!taskDone)//infinite looop will fire to ensure that the database is updated in every case
                {
                    taskDone = stopSendingMessage();
                }
            }
        }
    public bool stopSendingMessage()
        {
            bool smsFlagUpdated = true;
            try
            {
                
            }
            catch (Exception ex)
            {
                writeToLog(ex.Message);
            }
            return smsFlagUpdated;
        }
    }
    }
