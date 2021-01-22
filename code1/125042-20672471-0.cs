    internal static class FFMpegArgUtils
        {
            public static string GetEncodeVideoFFMpegArgs(string sSourceFile, MP4Info objMp4Info, double nMbps, int iWidth, int iHeight, bool bIncludeAudio, string sOutputFile)
            {
                //Ensure file contains a video stream, otherwise this command will fail
                if (objMp4Info != null && objMp4Info.VideoStreamCount == 0)
                {
                    throw new Exception("FFMpegArgUtils::GetEncodeVideoFFMpegArgs - mp4 does not contain a video stream");
                }
    
                int iBitRateInKbps = (int)(nMbps * 1000);
    
                
                StringBuilder sbArgs = new StringBuilder();
                sbArgs.Append(" -y -threads 2 -i \"" + sSourceFile + "\" -strict -2 "); // 0 tells it to choose how many threads to use
    
                if (bIncludeAudio == true)
                {
                    //sbArgs.Append(" -acodec libmp3lame -ab 96k");
                    sbArgs.Append(" -acodec aac -ar 44100 -ab 96k");
                }
                else
                {
                    sbArgs.Append(" -an");
                }
    
                
                sbArgs.Append(" -vcodec libx264 -level 41 -r 15 -crf 25 -g 15  -keyint_min 45 -bf 0");
    
                //sbArgs.Append(" -vf pad=" + iWidth + ":" + iHeight + ":" + iVideoOffsetX + ":" + iVideoOffsetY);
                sbArgs.Append(String.Format(" -vf \"scale=iw*min({0}/iw\\,{1}/ih):ih*min({0}/iw\\,{1}/ih),pad={0}:{1}:({0}-iw)/2:({1}-ih)/2\"",iWidth, iHeight));
    
                //Output File
                sbArgs.Append(" \"" + sOutputFile + "\"");
                return sbArgs.ToString();
            }
    
            public static string GetEncodeAudioFFMpegArgs(string sSourceFile, string sOutputFile)
            {
                var args = String.Format(" -y -threads 2 -i \"{0}\" -strict -2  -acodec aac -ar 44100 -ab 96k -vn \"{1}\"", sSourceFile, sOutputFile);
                return args;
    
    
                //return GetEncodeVideoFFMpegArgs(sSourceFile, null, .2, 854, 480, true, sOutputFile);
                //StringBuilder sbArgs = new StringBuilder();
                //int iWidth = 854;
                //int iHeight = 480;
                //sbArgs.Append(" -y -i \"" + sSourceFile + "\" -strict -2 "); // 0 tells it to choose how many threads to use
                //sbArgs.Append(" -acodec aac -ar 44100 -ab 96k");
                //sbArgs.Append(" -vcodec libx264 -level 41 -r 15 -crf 25 -g 15  -keyint_min 45 -bf 0");
                //sbArgs.Append(String.Format(" -vf \"scale=iw*min({0}/iw\\,{1}/ih):ih*min({0}/iw\\,{1}/ih),pad={0}:{1}:({0}-iw)/2:({1}-ih)/2\"", iWidth, iHeight));
                //sbArgs.Append(" \"" + sOutputFile + "\"");
                //return sbArgs.ToString();
            }
        }
    
    internal class CreateEncodedVideoCommand : ConsoleCommandBase
        {
            public event ProgressEventHandler OnProgressEvent;
    
            private string _sSourceFile;
            private  string _sOutputFolder;
            private double _nMaxMbps;
    
            public double BitrateInMbps
            {
                get { return _nMaxMbps; }
            }
    
            public int BitrateInKbps
            {
                get { return (int)Math.Round(_nMaxMbps * 1000); }
            }
    
            private int _iOutputWidth;
            private int _iOutputHeight;
    
            private bool _bIsConverting = false;
            //private TimeSpan _tsDuration;
            private double _nPercentageComplete;
            private string _sOutputFile;
            private string _sOutputFileName;
    
    
            private bool _bAudioEnabled = true;
            private string _sFFMpegPath;
            private string _sExePath;
            private string _sArgs;
            private MP4Info _objSourceInfo;
            private string _sOutputExt;
    
            /// <summary>
            /// Encodes an MP4 to the specs provided, quality is a value from 0 to 1
            /// </summary>
            /// <param name="nQuality">A value from 0 to 1</param>
            /// 
            public CreateEncodedVideoCommand(string sSourceFile, string sOutputFolder, string sFFMpegPath, double nMaxBitrateInMbps, MP4Info objSourceInfo, int iOutputWidth, int iOutputHeight, string sOutputExt)
            {
                _sSourceFile = sSourceFile;
                _sOutputFolder = sOutputFolder;
                _nMaxMbps = nMaxBitrateInMbps;
                _objSourceInfo = objSourceInfo;
                _iOutputWidth = iOutputWidth;
                _iOutputHeight = iOutputHeight;
                _sFFMpegPath = sFFMpegPath;
                _sOutputExt = sOutputExt;
            }
    
            public void SetOutputFileName(string sOutputFileName)
            {
                _sOutputFileName = sOutputFileName;
            }
    
    
            public override void Execute()
            {
                try
                {
                    _bIsConverting = false;
    
                    string sFileName = _sOutputFileName != null ? _sOutputFileName : Path.GetFileNameWithoutExtension(_sSourceFile) + "_" + _iOutputWidth + "." + _sOutputExt;
                    _sOutputFile = _sOutputFolder + "\\" + sFileName;
    
                    _sExePath = _sFFMpegPath;
                    _sArgs = FFMpegArgUtils.GetEncodeVideoFFMpegArgs(_sSourceFile, _objSourceInfo,_nMaxMbps, _iOutputWidth, _iOutputHeight, _bAudioEnabled, _sOutputFile);
    
                    InternalExecute(_sExePath, _sArgs);
                }
                catch (Exception objEx)
                {
                    DispatchException(objEx);
                }
            }
    
            public override string GetCommandInfo()
            {
                StringBuilder sbInfo = new StringBuilder();
                sbInfo.AppendLine("CreateEncodeVideoCommand");
                sbInfo.AppendLine("Exe: " + _sExePath);
                sbInfo.AppendLine("Args: " + _sArgs);
                sbInfo.AppendLine("[ConsoleOutput]");
                sbInfo.Append(ConsoleOutput);
                sbInfo.AppendLine("[ErrorOutput]");
                sbInfo.Append(ErrorOutput);
    
                return base.GetCommandInfo() + "\n" + sbInfo.ToString();
            }
    
            protected override void OnInternalCommandComplete(int iExitCode)
            {
                DispatchCommandComplete( iExitCode == 0 ? CommandResultType.Success : CommandResultType.Fail);
            }
    
            override protected void OnOutputRecieved(object sender, ProcessOutputEventArgs objArgs)
            {
                //FMPEG out always shows as Error
                base.OnOutputRecieved(sender, objArgs);
    
                if (_bIsConverting == false && objArgs.Data.StartsWith("Press [q] to stop encoding") == true)
                {
                    _bIsConverting = true;
                }
                else if (_bIsConverting == true && objArgs.Data.StartsWith("frame=") == true)
                {
                    //Capture Progress
                    UpdateProgressFromOutputLine(objArgs.Data);
                }
                else if (_bIsConverting == true && _nPercentageComplete > .8 && objArgs.Data.StartsWith("frame=") == false)
                {
                    UpdateProgress(1);
                    _bIsConverting = false;
                }
            }
    
            override protected void OnProcessExit(object sender, ProcessExitedEventArgs args)
            {
                _bIsConverting = false;
                base.OnProcessExit(sender, args);
            }
    
            override public void Abort()
            {
                if (_objCurrentProcessRunner != null)
                {
                    //_objCurrentProcessRunner.SendLineToInputStream("q");
                    _objCurrentProcessRunner.Dispose();
                }
            }
    
            #region Helpers
    
            //private void CaptureSourceDetailsFromOutput()
            //{
            //    String sInputStreamInfoStartLine = _colErrorLines.SingleOrDefault(o => o.StartsWith("Input #0"));
            //    int iStreamInfoStartIndex = _colErrorLines.IndexOf(sInputStreamInfoStartLine);
            //    if (iStreamInfoStartIndex >= 0)
            //    {
            //        string sDurationInfoLine = _colErrorLines[iStreamInfoStartIndex + 1];
            //        string sDurantionTime = sDurationInfoLine.Substring(12, 11);
    
            //        _tsDuration = VideoUtils.GetDurationFromFFMpegDurationString(sDurantionTime);
            //    }
            //}
    
            private void UpdateProgressFromOutputLine(string sOutputLine)
            {
                int iTimeIndex = sOutputLine.IndexOf("time=");
                int iBitrateIndex = sOutputLine.IndexOf(" bitrate=");
    
                string sCurrentTime = sOutputLine.Substring(iTimeIndex + 5, iBitrateIndex - iTimeIndex - 5);
                double nCurrentTimeInSeconds = double.Parse(sCurrentTime);
                double nPercentageComplete = nCurrentTimeInSeconds / _objSourceInfo.Duration.TotalSeconds;
    
                UpdateProgress(nPercentageComplete);
                //Console.WriteLine("Progress: " + _nPercentageComplete);
            }
    
            private void UpdateProgress(double nPercentageComplete)
            {
                _nPercentageComplete = nPercentageComplete;
                if (OnProgressEvent != null)
                {
                    OnProgressEvent(this, new ProgressEventArgs( _nPercentageComplete));
                }
            }
    
            #endregion
    
            //public TimeSpan Duration { get { return _tsDuration; } }
    
            public double Progress { get { return _nPercentageComplete;  } }
            public string OutputFile { get { return _sOutputFile; } }
    
            public bool AudioEnabled
            {
                get { return _bAudioEnabled; }
                set { _bAudioEnabled = value; }
            }
    }
    
    public abstract class ConsoleCommandBase : CommandBase, ICommand
        {
            protected ProcessRunner _objCurrentProcessRunner;
            protected   List<String> _colOutputLines;
            protected List<String> _colErrorLines;
                
    
            private int _iExitCode;
            
            public ConsoleCommandBase()
            {
                _colOutputLines = new List<string>();
                _colErrorLines = new List<string>();
            }
    
            protected void InternalExecute(string sExePath, string sArgs)
            {
                InternalExecute(sExePath, sArgs, null, null, null);
            }
    
            protected void InternalExecute(string sExePath, string sArgs, string sDomain, string sUsername, string sPassword)
            {
                try
                {
                    if (_objCurrentProcessRunner == null || _bIsRunning == false)
                    {
                        StringReader objStringReader = new StringReader(string.Empty);
    
                        _objCurrentProcessRunner = new ProcessRunner(sExePath, sArgs);
    
                        _objCurrentProcessRunner.SetCredentials(sDomain, sUsername, sPassword);
    
                        _objCurrentProcessRunner.OutputReceived += new ProcessOutputEventHandler(OnOutputRecieved);
                        _objCurrentProcessRunner.ProcessExited += new ProcessExitedEventHandler(OnProcessExit);
                        _objCurrentProcessRunner.Run();
    
                        _bIsRunning = true;
                        _bIsComplete = false;
                    }
                    else
                    {
                        DispatchException(new Exception("Processor Already Running"));
                    }
                }
                catch (Exception objEx)
                {
                    DispatchException(objEx);
                }
            }
    
            protected virtual void OnOutputRecieved(object sender, ProcessOutputEventArgs args)
            {
                try
                {
                    if (args.Error == true)
                    {
                        _colErrorLines.Add(args.Data);
                        //Console.WriteLine("Error: " + args.Data);
                    }
                    else
                    {
                        _colOutputLines.Add(args.Data);
                        //Console.WriteLine(args.Data);
                    }
                }
                catch (Exception objEx)
                {
                    DispatchException(objEx);
                }
            }
    
            protected virtual void OnProcessExit(object sender, ProcessExitedEventArgs args)
            {
                try
                {
                    Console.Write(ConsoleOutput);
                    _iExitCode = args.ExitCode;
    
                    _bIsRunning = false;
                    _bIsComplete = true;
    
                    //Some commands actually fail to succeed
                    //if(args.ExitCode != 0)
                    //{
                    //    DispatchException(new Exception("Command Failed: " + this.GetType().Name + "\nConsole: " + ConsoleOutput + "\nConsoleError: " + ErrorOutput));
                    //}
    
                    OnInternalCommandComplete(_iExitCode);
    
                    if (_objCurrentProcessRunner != null)
                    {
                        _objCurrentProcessRunner.Dispose();
                        _objCurrentProcessRunner = null;    
                    }
                }
                catch (Exception objEx)
                {
                    DispatchException(objEx);
                }
            }
    
            abstract protected void OnInternalCommandComplete(int iExitCode);
    
            protected string JoinLines(List<String> colLines)
            {
                StringBuilder sbOutput = new StringBuilder();
                colLines.ForEach( o => sbOutput.AppendLine(o));
                return sbOutput.ToString();
            }
    
            #region Properties
            public int ExitCode
            {
                get { return _iExitCode; }
            }
            #endregion
    
            public override string GetCommandInfo()
            {
                StringBuilder sbCommandInfo = new StringBuilder();
                sbCommandInfo.AppendLine("Command:  " + this.GetType().Name);
                sbCommandInfo.AppendLine("Console Output");
                if (_colOutputLines != null)
                {
                    foreach (string sOutputLine in _colOutputLines)
                    {
                        sbCommandInfo.AppendLine("\t" + sOutputLine);
                    }
                }
                sbCommandInfo.AppendLine("Error Output");
                if (_colErrorLines != null)
                {
                    foreach (string sErrorLine in _colErrorLines)
                    {
                        sbCommandInfo.AppendLine("\t" + sErrorLine);
                    }
                }
                return sbCommandInfo.ToString();
            }
    
            public String ConsoleOutput { get { return JoinLines(_colOutputLines); } }
            public String ErrorOutput { get { return JoinLines(_colErrorLines);} }
    
        }
    
    CommandBase : ICommand
        {
            protected IDedooseContext _context;
            protected Boolean _bIsRunning = false;
            protected Boolean _bIsComplete = false;
            
            #region Custom Events
            public event CommandCompleteEventHandler OnCommandComplete;
            event CommandCompleteEventHandler ICommand.OnCommandComplete
            {
                add { if (OnCommandComplete != null) { lock (OnCommandComplete) { OnCommandComplete += value; } } else { OnCommandComplete = new CommandCompleteEventHandler(value); } }
                remove { if (OnCommandComplete != null) { lock (OnCommandComplete) { OnCommandComplete -= value; } } }
            }
    
            public event UnhandledExceptionEventHandler OnCommandException;
            event UnhandledExceptionEventHandler ICommand.OnCommandException
            {
                add { if (OnCommandException != null) { lock (OnCommandException) { OnCommandException += value; } } else { OnCommandException = new UnhandledExceptionEventHandler(value); } }
                remove { if (OnCommandException != null) { lock (OnCommandException) { OnCommandException -= value; } } }
            }
    
            public event ProgressEventHandler OnProgressUpdate;
            event ProgressEventHandler ICommand.OnProgressUpdate
            {
                add { if (OnProgressUpdate != null) { lock (OnProgressUpdate) { OnProgressUpdate += value; } } else { OnProgressUpdate = new ProgressEventHandler(value); } }
                remove { if (OnProgressUpdate != null) { lock (OnProgressUpdate) { OnProgressUpdate -= value; } } }
            }
            #endregion
    
            protected CommandBase()
            {
                _context = UnityGlobalContainer.Instance.Context;
            }
    
            protected void DispatchCommandComplete(CommandResultType enResult)
            {
                if (enResult == CommandResultType.Fail)
                {
                    StringBuilder sbMessage = new StringBuilder();
                    sbMessage.AppendLine("Command Commpleted with Failure: "  + this.GetType().Name);
                    sbMessage.Append(GetCommandInfo());
                    Exception objEx = new Exception(sbMessage.ToString());
                    DispatchException(objEx);
                }
                else
                {
                    if (OnCommandComplete != null)
                    {
                        OnCommandComplete(this, new CommandCompleteEventArgs(enResult));
                    }
                }
            }
    
            protected void DispatchException(Exception objEx)
            {
                if (OnCommandException != null)
                { 
                    OnCommandException(this, new UnhandledExceptionEventArgs(objEx, true)); 
                }
                else
                {
                    _context.Logger.LogException(objEx, MethodBase.GetCurrentMethod());
                    throw objEx;
                }
            }
    
            protected void DispatchProgressUpdate(double nProgressRatio)
            {
                if (OnProgressUpdate != null) { OnProgressUpdate(this, new ProgressEventArgs(nProgressRatio)); } 
            }
    
            public virtual string GetCommandInfo()
            {
                return "Not Implemented: " + this.GetType().Name;
            }
    
            public virtual void Execute() { throw new NotImplementedException(); }
            public virtual void Abort() { throw new NotImplementedException(); }
    
            public Boolean IsRunning { get { return _bIsRunning; } }
            public Boolean IsComplete { get { return _bIsComplete; } }
    
            public double GetProgressRatio()
            {
                throw new NotImplementedException();
            }
        }
    
    public delegate void CommandCompleteEventHandler(object sender, CommandCompleteEventArgs e);
    
        public interface ICommand
        {
            event CommandCompleteEventHandler OnCommandComplete;
            event UnhandledExceptionEventHandler OnCommandException;
            event ProgressEventHandler OnProgressUpdate;
    
            double GetProgressRatio();
            string GetCommandInfo();
    
            void Execute();
            void Abort();
        }
