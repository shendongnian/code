    using System;
    using System.Collections.Generic;
    using System.Text;
    using EnvDTE;
    using EnvDTE80;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            [STAThread]
            static void Main(string[] args)
            {
                EnvDTE80.DTE2 dte;
                object obj = null;
                System.Type t = null;
    
                // Get the ProgID for DTE 8.0.
                t = System.Type.GetTypeFromProgID("VisualStudio.DTE.10.0",
                  true);
                // Create a new instance of the IDE.
                obj = System.Activator.CreateInstance(t, true);
                // Cast the instance to DTE2 and assign to variable dte.
                dte = (EnvDTE80.DTE2)obj;
    
                // Register the IOleMessageFilter to handle any threading 
                // errors.
                MessageFilter.Register();
                // Display the Visual Studio IDE.
                dte.MainWindow.Activate();
    
                // =====================================
                // ==Insert your automation code here.==
                // =====================================
                // For example, get a reference to the solution2 object
                // and do what you like with it.
                Solution2 soln = (Solution2)dte.Solution;
                System.Windows.Forms.MessageBox.Show
                  ("Solution count: " + soln.Count);
                // =====================================
                
                // All done, so shut down the IDE...
                dte.Quit();
                // and turn off the IOleMessageFilter.
                MessageFilter.Revoke();
                
            }
        }
    
        public class MessageFilter : IOleMessageFilter
        {
            //
            // Class containing the IOleMessageFilter
            // thread error-handling functions.
    
            // Start the filter.
            public static void Register()
            {
                IOleMessageFilter newFilter = new MessageFilter(); 
                IOleMessageFilter oldFilter = null; 
                int hr = CoRegisterMessageFilter(newFilter, out oldFilter);
                if (hr != 0)
                  Marshal.ThrowExceptionForHR(hr);
            }
    
            // Done with the filter, close it.
            public static void Revoke()
            {
                IOleMessageFilter oldFilter = null; 
                CoRegisterMessageFilter(null, out oldFilter);
            }
    
            //
            // IOleMessageFilter functions.
            // Handle incoming thread requests.
            int IOleMessageFilter.HandleInComingCall(int dwCallType, 
              System.IntPtr hTaskCaller, int dwTickCount, System.IntPtr 
              lpInterfaceInfo) 
            {
                //Return the flag SERVERCALL_ISHANDLED.
                return 0;
            }
    
            // Thread call was rejected, so try again.
            int IOleMessageFilter.RetryRejectedCall(System.IntPtr 
              hTaskCallee, int dwTickCount, int dwRejectType)
            {
                if (dwRejectType == 2)
                // flag = SERVERCALL_RETRYLATER.
                {
                    // Retry the thread call immediately if return >=0 & 
                    // <100.
                    return 99;
                }
                // Too busy; cancel call.
                return -1;
            }
    
            int IOleMessageFilter.MessagePending(System.IntPtr hTaskCallee, 
              int dwTickCount, int dwPendingType)
            {
                //Return the flag PENDINGMSG_WAITDEFPROCESS.
                return 2; 
            }
    
            // Implement the IOleMessageFilter interface.
            [DllImport("Ole32.dll")]
            private static extern int 
              CoRegisterMessageFilter(IOleMessageFilter newFilter, out 
              IOleMessageFilter oldFilter);
        }
    
        [ComImport(), Guid("00000016-0000-0000-C000-000000000046"), 
        InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
        interface IOleMessageFilter 
        {
            [PreserveSig]
            int HandleInComingCall( 
                int dwCallType, 
                IntPtr hTaskCaller, 
                int dwTickCount, 
                IntPtr lpInterfaceInfo);
    
            [PreserveSig]
            int RetryRejectedCall( 
                IntPtr hTaskCallee, 
                int dwTickCount,
                int dwRejectType);
    
            [PreserveSig]
            int MessagePending( 
                IntPtr hTaskCallee, 
                int dwTickCount,
                int dwPendingType);
        }
    }
