     public class UtilityManager
     {
          public Process UtilityProcess { get; private set; }
          private bool _isRunning;
          public UtilityManager() : this(null) {}
          public UtilityManager( Process process )
          {
              this. UtilityProcess = process ?? new Process();
              this._isRunning = false;
          }
          public void Start()
          {
              if (!_isRunning) {
              var startInfo = new ProcessStartInfo() {
                  CreateNoWindow = true,
                  UseShellExecute = true,
                  FileName = _cmdLine,
                  Arguments = _args
              };
              this.UtilityProcess.Start(startInfo);
              _isRunning = true;
            
          } else {
              throw new InvalidOperationException("Process already started");
          }
     }
