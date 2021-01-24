     public void WriteLog(string _szMessage, bool _bRealLog, bool _bAppend = true, string _szLogMessage = "", string _szLabel = "")
        {
            if (this.rtbLogs.InvokeRequired)
            {
                PrintLogDelegate d = new PrintLogDelegate(WriteLog);
                this.Invoke(d, new object[] { _szMessage, _bRealLog, _bAppend, _szLogMessage, _szLabel });
            }
            else
            {
                if (String.IsNullOrEmpty(rtbLogs.Text))
                {
                    rtbLogs.AppendText($"{_szMessage}");
                    rtbLogs.ScrollToCaret();
                }
                else
                {
                    rtbLogs.AppendText(Environment.NewLine + $"{_szMessage}");
                    rtbLogs.ScrollToCaret();
                }
                if (_bRealLog == true)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Clear();
                    if (_bAppend == true)
                    {
                        sb.AppendLine();
                    }
                    sb.Append($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss,FFF")} [SY] {_szLabel} {_szLogMessage}");
                    File.AppendAllText(Properties.Settings.Default.szDirectoryPath + "\\" + "log.log", sb.ToString());
                    sb.Clear();
                }
            }
        }
 
