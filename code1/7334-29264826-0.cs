        [ThreadStatic()]
        static Microsoft.Office.Interop.Word.Application wordObj = null;
        public Form1()
        {
            InitializeComponent();
        }
        public bool OpenDoc(string documentName)
        {
            bool bSuccss = false;
            System.Threading.Thread newThread;
            int iRetryCount;
            int iWait;
            int pid = 0;
            int iMaxRetry = 3;
            try
            {
                iRetryCount = 1;
            TRY_OPEN_DOCUMENT:
                iWait = 0;
                newThread = new Thread(() => OpenDocument(documentName, pid));
                newThread.Start();
            WAIT_FOR_WORD:
                Thread.Sleep(1000);
                iWait = iWait + 1;
                if (iWait < 60) //1 minute wait
                    goto WAIT_FOR_WORD;
                else
                {
                    iRetryCount = iRetryCount + 1;
                    newThread.Abort();
                    //'-----------------------------------------
                    //'killing unresponsive word instance
                    if ((wordObj != null))
                    {
                        try
                        {
                            Process.GetProcessById(pid).Kill();
                            Marshal.ReleaseComObject(wordObj);
                            wordObj = null;
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                    //'----------------------------------------
                    if (iMaxRetry >= iRetryCount)
                        goto TRY_OPEN_DOCUMENT;
                    else
                        goto WORD_SUCCESS;
                }
            }
            catch (Exception ex)
            {
                bSuccss = false;
            }
        WORD_SUCCESS:
            return bSuccss;
        }
        private bool OpenDocument(string docName, int pid)
        {
            bool bSuccess = false;
            Microsoft.Office.Interop.Word.Application tWord;
            DateTime sTime;
            DateTime eTime;
            try
            {
                tWord = new Microsoft.Office.Interop.Word.Application();
                sTime = DateTime.Now;
                wordObj = new Microsoft.Office.Interop.Word.Application();
                eTime = DateTime.Now;
                tWord.Quit(false);
                Marshal.ReleaseComObject(tWord);
                tWord = null;
                wordObj.Visible = false;
                pid = GETPID(sTime, eTime);
                //now do stuff
                wordObj.Documents.OpenNoRepairDialog(docName);
                //other code
                if (wordObj != null)
                {
                    wordObj.Quit(false);
                    Marshal.ReleaseComObject(wordObj);
                    wordObj = null;
                }
                bSuccess = true;
            }
            catch
            { }
            return bSuccess;
        }
        private int GETPID(System.DateTime startTime, System.DateTime endTime)
        {
            int pid = 0;
            try
            {
                foreach (Process p in Process.GetProcessesByName("WINWORD"))
                {
                    if (string.IsNullOrEmpty(string.Empty + p.MainWindowTitle) & p.HasExited == false && (p.StartTime.Ticks >= startTime.Ticks & p.StartTime.Ticks <= endTime.Ticks))
                    {
                        pid = p.Id;
                        break;
                    }
                }
            }
            catch
            {
            }
            return pid;
        }
