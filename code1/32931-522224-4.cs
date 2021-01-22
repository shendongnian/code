    // *********************************************************************
    // [DCOM Productions .NET]
    // [DPDN], [Visual Studio Launcher]
    //
    //   THIS FILE IS PROVIDED "AS-IS" WITHOUT ANY WARRANTY OF ANY KIND. ANY
    //   MODIFICATIONS TO THIS FILE IN ANY WAY ARE YOUR SOLE RESPONSIBILITY.
    //
    // [Copyright (C) DCOM Productions .NET  All rights reserved.]
    // *********************************************************************
    
    namespace VisualStudioLauncher
    {
        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Windows.Forms;
        using System.Threading;
        using VisualStudioLauncher.Common.Objects;
        using VisualStudioLauncher.Forms;
        using System.Drawing;
        using VisualStudioLauncher.Common.Data;
        using System.IO;
	    static class Program
	    {
	        #region Properties
	
	        private static ProjectLocationList m_ProjectLocationList;
	        /// <summary>
	        /// Gets or Sets the ProjectsLocationList
	        /// </summary>
	        public static ProjectLocationList ProjectLocationList
	        {
	            get
	            {
	                return m_ProjectLocationList;
	            }
	
	            set
	            {
	                m_ProjectLocationList = value;
	            }
	        }
	
	        private static ShellProcessList m_ShellProcessList = null;
	        /// <summary>
	        /// Gets or Sets the ShellProcessList
	        /// </summary>
	        public static ShellProcessList ShellProcessList
	        {
	            get
	            {
	                return m_ShellProcessList;
	            }
	
	            set
	            {
	                m_ShellProcessList = value;
	            }
	        }
	
	        private static NotifyIcon m_TrayIcon;
	        /// <summary>
	        /// Gets the programs tray application.
	        /// </summary>
	        public static NotifyIcon TrayIcon
	        {
	            get
	            {
	                return m_TrayIcon;
	            }
	        }
	
	        private static bool m_UserExitCalled;
	        /// <summary>
	        /// Gets a value indicating whether the user has called for an Application.Exit
	        /// </summary>
	        public static bool UserExitCalled
	        {
	            get
	            {
	                return m_UserExitCalled;
	            }
	
	            set
	            {
	                m_UserExitCalled = value;
	            }
	        }
	
	        // TODO: Finish implementation, then use this for real.
	        private static ApplicationConfiguration m_ApplicationConfiguration = null;
	        /// <summary>
	        /// Gets the application configuration
	        /// </summary>
	        public static ApplicationConfiguration ApplicationConfiguration
	        {
	            get
	            {
	                if (m_ApplicationConfiguration == null)
	                    m_ApplicationConfiguration = ApplicationConfiguration.LoadConfigSection(@"./settings.config");
	
	                return m_ApplicationConfiguration;
	            }
	        }
	
	
	        #endregion
	
	        /// <summary>
	        /// The main entry point for the application.
	        /// </summary>
	        [STAThread]
	        static void Main(string[] args)
	        {
	            if (args.Length > 0)
	            {
	                if (args[0].ToLower() == "-rmvptr")
	                {
	                    for (int i = 1; i < args.Length; i++) {
	                        try {
	                            if (File.Exists(Application.StartupPath + @"\\" + args[i])) {
	                                File.Delete(Application.StartupPath + @"\\" + args[i]);
	                            }
	                        }
	                        catch { /* this isn't critical, just convenient */ }
	                    }
	                }
	            }
	
	            Application.EnableVisualStyles();
	            Application.SetCompatibleTextRenderingDefault(false);
	
	            SplashForm splashForm = new SplashForm();
	            splashForm.Show();
	
	            while (!UserExitCalled)
	            {
	                Application.DoEvents();
	                Thread.Sleep(1);
	            }
	
	            if (m_TrayIcon != null)
	            {
	                m_TrayIcon.Icon = null;
	                m_TrayIcon.Visible = false;
	                m_TrayIcon.Dispose();
	
	                GC.Collect();
	            }
	        }
	
	        #region System Tray Management
	
	        public static void SetupTrayIcon()
	        {
	            m_TrayIcon = new NotifyIcon();
	            m_TrayIcon.Text = Resources.UserInterfaceStrings.ApplicationName;
	            m_TrayIcon.Visible = false; // This will be set visible when the context menu is generated
	            m_TrayIcon.MouseDoubleClick += new MouseEventHandler(m_TrayIcon_MouseDoubleClick);
	
	            if (Orcas.IsInstalled)
	            {
	                m_TrayIcon.Icon = Orcas.Icon;
	            }
	            else if (Whidbey.IsInstalled) {
	                m_TrayIcon.Icon = Whidbey.Icon;
	            }
	            else {
	                m_TrayIcon.Icon = SystemIcons.Warning;
	                m_TrayIcon.Text = "Visual Studio is not installed. VSL cannot run properly.";
	            }
	        }
	
	        static void m_TrayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
	        {
	            if (e.Button != MouseButtons.Left)
	            {
	                return;
	            }
	
	            SettingsForm settingsForm = new SettingsForm();
	            settingsForm.Show();
	        }
	        #endregion
	    }
    }
