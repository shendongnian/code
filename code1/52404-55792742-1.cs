        public void OpenWord(string Path, bool IsVisible)
        {
            MessageFilter.Register();
            object oMissing = Missing.Value;
            GUIDCaption = Guid.NewGuid().ToString();
            wordApp = new Microsoft.Office.Interop.Word.ApplicationClass();
            wordApp.Visible = IsVisible;
            wordApp.Caption = GUIDCaption;
            object oPath = Path;
            wordDoc = wordApp.Documents.Open(ref  oPath, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);
        }
        /// <summary>
        /// 关闭文件
        /// </summary>
        public void CloseWord()
        {
            object oMissing = Missing.Value;
            GUIDCaption = "";
            if (null != wordDoc)
            {
                wordDoc.Close(ref oMissing, ref oMissing, ref oMissing);
            }
            if (null != wordApp)
            {
                wordApp.Quit(ref oMissing, ref oMissing, ref oMissing);
            }
            MessageFilter.Revoke();
            GC.Collect();
            KillwordProcess();
        }
        /// <summary>
        /// 结束word进程
        /// </summary>
        public void KillwordProcess()
        {
            try
            {
                Process[] myProcesses;
                //DateTime startTime;
                myProcesses = Process.GetProcessesByName("WINWORD");
                //通过进程窗口标题判断
                foreach (Process myProcess in myProcesses)
                {
                    if (null != GUIDCaption && GUIDCaption.Length > 0 && myProcess.MainWindowTitle.Equals(GUIDCaption))
                    {
                        myProcess.Kill();
                    }
                }
                MessageFilter.Revoke();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
