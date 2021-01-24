    using System;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading;
    using System.Windows.Automation;
    
    namespace Application.Automation.WindowsDesktop.Interactions
    {
        using System.Diagnostics;
        using System.Linq;
        using System.Windows.Forms;
    
        public static class DesktopInteractions
        {
            private static Int32 WM_KEYDOWN = 0x100;
            private static Int32 WM_KEYUP = 0x101;
    
            [return: MarshalAs(UnmanagedType.Bool)]
            [DllImport("user32.dll", SetLastError = true)]
            static extern bool PostMessage(IntPtr hWnd, int Msg, System.Windows.Forms.Keys wParam, int lParam);
    
            /// <summary>
            /// This method attempts to interact with the IE Security Certificate Window
            /// <exception> Throws InvalidOperationException if it can not locate the window or the submit control </exception>
            /// </summary>
            public static void HandleWindowsSecurityWindow(string certificateName)
            {
                AutomationElement securityCertificateWindow = null;
    
                int waitSeconds = 1;
                int currentAttempt = 0;
                int maximumAttempts = 300;
    
                //Find Security Window
                AutomationElement certificateWindow = null;
                while (currentAttempt <= maximumAttempts && certificateWindow == null)
                {
                    Debug.WriteLine("Searching for security window");
                    var ieWindows = AutomationElement.RootElement
                                                     .FindAll(TreeScope.Children,
                                                              new PropertyCondition(AutomationElement.ControlTypeProperty,
                                                                                    ControlType.Pane))
                                                     .Cast<AutomationElement>()
                                                     .Where(window => window.Current.Name.Contains("Internet Explorer"));
    
                    Debug.WriteLine($"Found {ieWindows.Count()} IE windows");
                    foreach (var window in ieWindows)
                    {
                        Debug.WriteLine($"Looking for security window");
                        certificateWindow = window.FindFirst(TreeScope.Descendants,
                                                             new PropertyCondition(AutomationElement.ClassNameProperty,
                                                                                   "#32770")) ??
                                            certificateWindow;
                    }
    
                    if (certificateWindow == null)
                    {
                        Thread.Sleep((int) TimeSpan.FromSeconds(1)
                                                   .TotalMilliseconds);
                    }
    
                    currentAttempt++;
                }
    
                if (certificateWindow != null)
                {
                    Debug.WriteLine("Security window found");
    
                    if (certificateName != null)
                    {
                        // Select the certificate
                        Debug.WriteLine($"Searching for certificate named '{certificateName}'.");
                        var certificateListItem = certificateWindow.FindFirst(TreeScope.Descendants,
                                                                              new AndCondition(new PropertyCondition(AutomationElement.ControlTypeProperty,
                                                                                                                     ControlType.ListItem),
                                                                                               new PropertyCondition(AutomationElement.NameProperty,
                                                                                                                     certificateName)));
                        if (certificateListItem == null)
                        {
                            throw new ArgumentException($"No certificate found with the name '{certificateName}'.");
                        }
    
                        Debug.WriteLine("Certificate found");
                        // This is the only way I could "click" on the desired certificate.  Focus the item, then simulate pressing the space-bar.
                        certificateListItem.SetFocus();
                        PostMessage((IntPtr) certificateWindow.Current.NativeWindowHandle, WM_KEYDOWN, Keys.Space, 0);
                        PostMessage((IntPtr) certificateWindow.Current.NativeWindowHandle, WM_KEYUP, Keys.Space, 0);
                    }
                    else
                    {
                        Debug.WriteLine("No certificate specified, using default.");
                    }
    
                    // Click to OK button
                    Debug.WriteLine("Clicking OK");
                    var okButton = certificateWindow.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, "OK"));
                    var click = (InvokePattern) okButton.GetCurrentPattern(InvokePattern.Pattern);
                    click.Invoke();
                }
                else
                {
                    throw new InvalidOperationException("Unable to get a handle on the Security certification window.");
                }
            }
        }
    }
