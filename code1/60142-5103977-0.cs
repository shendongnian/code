    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using SimpleTestForm.Properties;
    using System.Drawing;
    namespace SimpleTestForm
    {
        static class Program
        {
            static MultiMainFormAppContext appContext;
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                appContext = new MultiMainFormAppContext();
                Application.Run(appContext);
            }
            /// <summary>
            /// Create a new MainForm and restore the form size and position if necessary. This method can be called like from Menu File > New click event.
            /// </summary>
            /// <returns></returns>
            public static MainForm createNewMainForm()
            {
                return appContext.createNewMainForm();
            }
            /// <summary>
            /// Get the current active MainForm event if a dialog is opened. Useful to create Dictionary (MainForm, T) to store Form/document dependent field. Please set the Owner of child form to prevent null reference exception.
            /// </summary>
            /// <returns></returns>
            public static MainForm GetCurrentMainFormInstance()
            {
                Form mainForm = Form.ActiveForm;
                while (!(mainForm is MainForm) && mainForm.Owner != null)
                    mainForm = mainForm.Owner;
                return mainForm as MainForm;
            }
        }
        class MultiMainFormAppContext : ApplicationContext
        {
            List<MainForm> mainForms = new List<MainForm>();
            Point newRestoredLocation = Point.Empty;
            internal MultiMainFormAppContext()
            {
                createNewMainForm();
            }
            internal MainForm createNewMainForm()
            {
                MainForm mainForm = new MainForm();
                mainForm.FormClosed += new FormClosedEventHandler(mainForm_FormClosed);
                mainForm.LocationChanged += new EventHandler(mainForm_LocationChanged);
                mainForms.Add(mainForm);
                RestoreFormSizeNPosition(mainForm);
                mainForm.Show();
                return mainForm;
            }
            /// <summary>
            /// Restore the form size and position with multi monitor support.
            /// </summary>
            private void RestoreFormSizeNPosition(MainForm mainForm)
            {
                // this is the default
                mainForm.WindowState = FormWindowState.Normal;
                mainForm.StartPosition = FormStartPosition.WindowsDefaultBounds;
                // check if the saved bounds are nonzero and visible on any screen
                if (Settings.Default.WindowPosition != Rectangle.Empty &&
                    IsVisibleOnAnyScreen(Settings.Default.WindowPosition))
                {
                    // first set the bounds
                    mainForm.StartPosition = FormStartPosition.Manual;
                    mainForm.DesktopBounds = Settings.Default.WindowPosition;
                    // afterwards set the window state to the saved value (which could be Maximized)
                    mainForm.WindowState = Settings.Default.WindowState;
                }
                else
                {
                    // this resets the upper left corner of the window to windows standards
                    mainForm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    // we can still apply the saved size if not empty
                    if (Settings.Default.WindowPosition != Rectangle.Empty)
                    {
                        mainForm.Size = Settings.Default.WindowPosition.Size;
                    }
                }
            }
            private void SaveFormSizeNPosition(MainForm mainForm)
            {
                // only save the WindowState as Normal or Maximized
                Settings.Default.WindowState = FormWindowState.Normal;
                if (mainForm.WindowState == FormWindowState.Normal || mainForm.WindowState == FormWindowState.Maximized)
                    Settings.Default.WindowState = mainForm.WindowState;
                if (mainForm.WindowState == FormWindowState.Normal)
                {
                    Settings.Default.WindowPosition = mainForm.DesktopBounds;
                }
                else
                {
                    if (newRestoredLocation == Point.Empty)
                        Settings.Default.WindowPosition = mainForm.RestoreBounds;
                    else
                        Settings.Default.WindowPosition = new Rectangle(newRestoredLocation, mainForm.RestoreBounds.Size);
                }
                Settings.Default.Save();
            }
            private bool IsVisibleOnAnyScreen(Rectangle rect)
            {
                foreach (Screen screen in Screen.AllScreens)
                {
                    if (screen.WorkingArea.IntersectsWith(rect))
                        return true;
                }
                return false;
            }
            void mainForm_LocationChanged(object sender, EventArgs e)
            {
                MainForm mainForm = sender as MainForm;
                if (mainForm.WindowState == FormWindowState.Maximized)
                {
                    // get the center location of the form incase like RibbonForm will be bigger and maximized Location wll be negative value that Screen.FromPoint(mainForm.Location) will going to the other monitor resides on the left or top of primary monitor.
                    // Another thing, you might consider the form is in the monitor even if the location (top left corner) is on another monitor because majority area is on the monitor, so center point is the best way.
                    Point centerFormMaximized = new Point (mainForm.DesktopBounds.Left + mainForm.DesktopBounds.Width/2, mainForm.DesktopBounds.Top + mainForm.DesktopBounds.Height/2);
                    Point centerFormRestored = new Point(mainForm.RestoreBounds.Left + mainForm.RestoreBounds.Width / 2, mainForm.RestoreBounds.Top + mainForm.RestoreBounds.Height / 2);
                    Screen screenMaximized = Screen.FromPoint(centerFormMaximized);
                    Screen screenRestored = Screen.FromPoint(centerFormRestored);
                    // we need to change the Location of mainForm.RestoreBounds to the new screen where the form currently maximized.
                    // RestoreBounds does not update the Location if you change the screen but never restore to FormWindowState.Normal
                    if (screenMaximized.DeviceName != screenRestored.DeviceName)
                    {
                        newRestoredLocation = mainForm.RestoreBounds.Location;
                        int screenOffsetX = screenMaximized.Bounds.Location.X - screenRestored.Bounds.Location.X;
                        int screenOffsetY = screenMaximized.Bounds.Location.Y - screenRestored.Bounds.Location.Y;
                        newRestoredLocation.Offset(screenOffsetX, screenOffsetY);
                        return;
                    }
                }
                newRestoredLocation = Point.Empty;
            }
            void mainForm_FormClosed(object sender, FormClosedEventArgs e)
            {
                MainForm mainForm = sender as MainForm;
                SaveFormSizeNPosition(mainForm);
                mainForm.FormClosed -= new FormClosedEventHandler(mainForm_FormClosed);
                mainForm.LocationChanged -= new EventHandler(mainForm_LocationChanged);
                mainForm.Dispose();
                mainForms.Remove(mainForm);
                if (mainForms.Count == 0) ExitThread();
            }
        }
    }
