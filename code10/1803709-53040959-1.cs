    using System;
    using System.Collections;
    using System.Runtime.InteropServices;
    
    namespace HRTC.CustomActions.Helpers
    {
        public class LocalServiceHelper
        {
            //Change service recovery option settings
            private const int ServiceAllAccess = 0xF01FF;
            private const int ScManagerAllAccess = 0xF003F;
            private const int ServiceConfigFailureActions = 0x2;
            private const int ErrorAccessDenied = 5;
    
           
            public static void ChangeRevoveryOption(string serviceName, ServiceRecoveryOptionHelper.RecoverAction firstFailureAction,
                ServiceRecoveryOptionHelper.RecoverAction secondFailureAction, ServiceRecoveryOptionHelper.RecoverAction thirdFailureAction)
            {
                try
                {
                    // Open the service control manager
                    var scmHndl = ServiceRecoveryOptionHelper.OpenSCManager(null, null, ScManagerAllAccess);
                    if (scmHndl.ToInt32() <= 0)
                        return;
    
                    // Open the service
                    var svcHndl = ServiceRecoveryOptionHelper.OpenService(scmHndl, serviceName, ServiceAllAccess);
    
                    if (svcHndl.ToInt32() <= 0)
                        return;
    
                    var failureActions = new ArrayList
                    {
                        // First Failure Actions and Delay (msec)
                        new FailureAction(firstFailureAction, 0),
                        // Second Failure Actions and Delay (msec)
                        new FailureAction(secondFailureAction, 0),
                        // Subsequent Failures Actions and Delay (msec)
                        new FailureAction(thirdFailureAction, 0)
                    };
    
                    var numActions = failureActions.Count;
                    var myActions = new int[numActions * 2];
                    var currInd = 0;
    
                    foreach (FailureAction fa in failureActions)
                    {
                        myActions[currInd] = (int) fa.Type;
                        myActions[++currInd] = fa.Delay;
                        currInd++;
                    }
    
                    // Need to pack 8 bytes per struct
                    var tmpBuf = Marshal.AllocHGlobal(numActions * 8);
    
                    // Move array into marshallable pointer
                    Marshal.Copy(myActions, 0, tmpBuf, numActions * 2);
    
                    // Set the SERVICE_FAILURE_ACTIONS struct
                    var config =
                        new ServiceRecoveryOptionHelper.ServiceFailureActions
                        {
                            cActions = 3,
                            dwResetPeriod = 0,
                            lpCommand = null,
                            lpRebootMsg = null,
                            lpsaActions = new IntPtr(tmpBuf.ToInt32())
                        };
    
                    // Call the ChangeServiceFailureActions() abstraction of ChangeServiceConfig2()
                    var result =
                        ServiceRecoveryOptionHelper.ChangeServiceFailureActions(svcHndl, ServiceConfigFailureActions,
                            ref config);
    
                    //Check the return
                    if (!result)
                    {
                        var err = ServiceRecoveryOptionHelper.GetLastError();
                        if (err == ErrorAccessDenied)
                        {
                            throw new Exception("Access Denied while setting Failure Actions");
    
                        }
    
                        // Free the memory
                        Marshal.FreeHGlobal(tmpBuf);
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Unable to set service recovery options");
                }
            }
        }
        
    }
