    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    
    namespace TestApp
    {
        static class MainEntryClass
        {
            /// 
            /// The main entry point for the application.
            /// 
            [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                C2F TestApp = new C2F();
                Application.Run();
            }
        }
    
        class C2F
        {
            System.ComponentModel.Container component;
            System.Drawing.Icon icon;
            ContextMenuStrip rightClickMenu = new ContextMenuStrip();
            NotifyIcon trayIcon;
            ToolStripMenuItem options = new ToolStripMenuItem();
            ToolStripMenuItem restore = new ToolStripMenuItem();
            ToolStripMenuItem exit = new ToolStripMenuItem();
            ToolStripSeparator seperator = new ToolStripSeparator();
    
            public C2F()
            {
                InitializeComponent();
            }
    
            private void InitializeComponent()
            {
                icon = new System.Drawing.Icon(@"C:\PathToIcon\iconfile.ico");
                component = new System.ComponentModel.Container();
                trayIcon = new NotifyIcon(component);
                trayIcon.Text = "Bill Reminder";
                trayIcon.Icon = icon;
                trayIcon.Visible = true;
                trayIcon.DoubleClick += new EventHandler(trayIcon_DoubleClick);
                trayIcon.ContextMenuStrip = rightClickMenu;
    
                rightClickMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[]
                {
                    options,
                    seperator,
                    restore,
                    exit
                });
    
                options.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                options.Text = "Options";
                options.Click += new EventHandler(options_Click);
    
                restore.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                restore.Text = "Restore Window";
                restore.Click += new EventHandler(restore_Click);
    
                exit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                exit.Text = "Exit";
                exit.Click += new EventHandler(exit_Click);
            }
    
            void exit_Click(object sender, EventArgs e)
            {
                Application.Exit();
            }
    
            void restore_Click(object sender, EventArgs e)
            {
                FormName showWindow = new FormName();
                showWindow.Show();
            }
    
            void options_Click(object sender, EventArgs e)
            {
                Settings_Window settings = new Settings_Window();
                settings.Show();
            }
    
            void trayIcon_DoubleClick(object sender, EventArgs e)
            {
                FormName showWindow = new FormName();
                showWindow.Show();
            }
        }
    
    }
