using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AxMSTSCLib;
using MSTSCLib;
using System.Runtime.InteropServices;
namespace AutoLogin
{
    public partial class Form1 : Form
    {
        private AxMSTSCLib.AxMsRdpClient5 rdpClient;
        public Form1()
        {
            InitializeComponent();
            rdpClient = new AxMSTSCLib.AxMsRdpClient5();
            ((ISupportInitialize)rdpClient).BeginInit();
            rdpClient.Enabled = true;
            rdpClient.Location = new System.Drawing.Point(0, 0);
            rdpClient.Name = "MsRdpClient";
            rdpClient.Size = ClientSize;
            rdpClient.TabIndex = 1;
            rdpClient.Anchor = (AnchorStyles)
                (AnchorStyles.Top | AnchorStyles.Bottom |
                 AnchorStyles.Left | AnchorStyles.Right);
            Controls.Add(rdpClient);
            ((ISupportInitialize)rdpClient).EndInit();
        }
        void axRemoteDesktop_OnDisconnected
            (object sender, IMsTscAxEvents_OnDisconnectedEvent e)
        {
            Application.Idle += ExitTimerEvent;
        }
        public void ExitTimerEvent(object source, EventArgs e)
        {
            Application.Idle -= ExitTimerEvent;
            // Attempt to close down the session we just connected to (there
            // appears to be no way to get the session id, so we just close all
            // disconnected sessions.
            if (rdpClient.Connected == 1) {
                rdpClient.Disconnect();
            }
            LogoffDisconnectedSessions();
            Close();
        }
        private Timer logoffTimer;
        private void Form1_Load(object sender, EventArgs e)
        {
            // Close down any existing disconnected sessions, the number of
            // available sessions is limited.
            LogoffDisconnectedSessions();
            String username = "username";
            String password = "password";
            rdpClient.Server = "localhost";
            rdpClient.UserName = username;
            rdpClient.AdvancedSettings2.ClearTextPassword = password;
            rdpClient.Domain = "";
            rdpClient.FullScreen = false;
            rdpClient.AdvancedSettings2.RedirectDrives = false;
            rdpClient.AdvancedSettings2.RedirectPrinters = false;
            rdpClient.AdvancedSettings2.RedirectPorts = false;
            rdpClient.AdvancedSettings2.RedirectSmartCards = false;
            rdpClient.AdvancedSettings6.RedirectClipboard = false;
            rdpClient.AdvancedSettings6.MinutesToIdleTimeout = 1;
            
            rdpClient.OnDisconnected += new 
                AxMSTSCLib.IMsTscAxEvents_OnDisconnectedEventHandler
                    (axRemoteDesktop_OnDisconnected);
            
            rdpClient.Connect();
            logoffTimer = new Timer();
            logoffTimer.Tick += new EventHandler(LogoutTimerEvent);
            logoffTimer.Interval = 150000;
            logoffTimer.Start();
        }
        private void Form1_Close(object sender, FormClosedEventArgs e)
        {
            Application.Idle -= ExitTimerEvent;
            if (rdpClient.Connected == 1) {
                rdpClient.Disconnect();
            }
        }
        public void LogoutTimerEvent(object source, EventArgs e)
        {
            logoffTimer.Stop();
            rdpClient.Disconnect();
        }
        enum WTS_CONNECTSTATE_CLASS
        {
            WTSActive,
            WTSConnected,
            WTSConnectQuery,
            WTSShadow,
            WTSDisconnected,
            WTSIdle,
            WTSListen,
            WTSReset,
            WTSDown,
            WTSInit
        };
        [StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto)]
        struct WTS_SESSION_INFO
        {
            public int SessionId;
            public string pWinStationName;
            public WTS_CONNECTSTATE_CLASS State;
        }
        [DllImport("wtsapi32.dll")]
        private static extern bool WTSLogoffSession(IntPtr hServer, int SessionId, bool bWait);
        private static IntPtr WTS_CURRENT_SERVER_HANDLE = IntPtr.Zero;
        [DllImport("wtsapi32.dll", CharSet = CharSet.Auto)]
        private static extern bool WTSEnumerateSessions(
                IntPtr hServer,
                [MarshalAs(UnmanagedType.U4)]
                int Reserved,
                [MarshalAs(UnmanagedType.U4)]
                int Version,
                ref IntPtr ppSessionInfo,
                [MarshalAs(UnmanagedType.U4)]
                ref int pCount);
        [DllImport("wtsapi32.dll")]
        private static extern void WTSFreeMemory(IntPtr pMemory);
        private void LogoffDisconnectedSessions()
        {
            IntPtr buffer = IntPtr.Zero;
            int count = 0;
            if (WTSEnumerateSessions(WTS_CURRENT_SERVER_HANDLE, 0, 1,
                                     ref buffer, ref count)) {
                WTS_SESSION_INFO sessionInfo = new WTS_SESSION_INFO();
                
                for (int index = 0; index < count; index++) {
                    sessionInfo = (WTS_SESSION_INFO)Marshal.PtrToStructure(
                       new IntPtr(buffer.ToInt32() +
                                  (Marshal.SizeOf(sessionInfo) * index)),
                       typeof(WTS_SESSION_INFO));
                    WTS_CONNECTSTATE_CLASS state = sessionInfo.State;
                    if (state == WTS_CONNECTSTATE_CLASS.WTSDisconnected)
                    {
                        WTSLogoffSession(WTS_CURRENT_SERVER_HANDLE,
                                         sessionInfo.SessionId, true);
                    }
                }
            }
            WTSFreeMemory(buffer);
        }
    }
}
