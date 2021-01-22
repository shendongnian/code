    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    
    namespace Test_20170308_01
    {
    	public partial class Form1 : Form
    	{
    		[DllImportAttribute("kernel32.dll", EntryPoint = "SetProcessWorkingSetSize", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            private static extern int SetProcessWorkingSetSize(IntPtr process, int minimumWorkingSetSize, int maximumWorkingSetSize);
            public static void FlushMemory()
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                if (Environment.OSVersion.Platform == PlatformID.Win32NT)
                {
                    SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
                }
            }
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void addWeb()
            {
                WebBrowserD webBrowser1 = new WebBrowserD();
                webBrowser1.Size = new Size(1070, 585);
                this.Controls.Add(webBrowser1);
                webBrowser1.Navigate("about:blank");
            }
    
            private void RemoveWeb()
            {
                foreach (Control ctrl in this.Controls)
                {
                    if (ctrl is  WebBrowserD)
                    {
                        WebBrowserD web = (WebBrowserD)ctrl;
                        this.Controls.Remove(ctrl);
                        web.Navigate("about:blank");
                        web.Dispose(true);
                        FlushMemory();
                    }
                }
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                addWeb();
            }
    
            private void button2_Click(object sender, EventArgs e)
            {
                RemoveWeb();
            }
    
    		private void button3_Click(object sender, EventArgs e)
    		{
    		    foreach (Control ctrl in this.Controls)
    		    {
    		        if (ctrl is WebBrowserD)
    		        {
    		            WebBrowserD axweb = (WebBrowserD)ctrl;
    		            axweb.Navigate(textBox1.Text);
    		            FlushMemory();
    		        }
    		    }
    		}
        }
    
    	public class WebBrowserD : WebBrowser
    	{
    		internal void Dispose(bool disposing)
    		{
                // call WebBrower.Dispose(bool)
                base.Dispose(disposing);
    		}
    	}
    }
