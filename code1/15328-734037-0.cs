    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.ServiceProcess;
    using System.Diagnostics;
    namespace MyCode
    {
        class MyService : ServiceBase
        {
            public MyService()
            {
                this.CanHandleSessionChangeEvent = true;
            }
            protected override void OnSessionChange(SessionChangeDescription changeDescription)
            {
                switch (changeDescription.Reason)
                {
                    case SessionChangeReason.SessionLogon:
                        Debug.WriteLine(changeDescription.SessionId + " logon");
                        break;
                    case SessionChangeReason.SessionLogoff:
                        Debug.WriteLine(changeDescription.SessionId + " logoff");
                        break;
                    case SessionChangeReason.SessionLock:
                        Debug.WriteLine(changeDescription.SessionId + " lock");
                        break;
                    case SessionChangeReason.SessionUnlock:
                        Debug.WriteLine(changeDescription.SessionId + " unlock");
                        break;
                }
    
                base.OnSessionChange(changeDescription);
            }
        }
    }
