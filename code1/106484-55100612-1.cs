        namespace Watcher
        {
            class Static
            {
                public static DateTime lastDomain { get; set; }
            }
            public partial class Form1 : Form
           {
                int minMs = 20;//time for blocking in ms
                public Form1()
                {
                    InitializeComponent();
                    Static.lastDomain = new DateTime(1970, 1, 1, 0, 0, 0);  
                    Start();
                }
                 private void Start()//Start watcher
                 {
                    //...
                    domain.Changed += new FileSystemEventHandler(Domain);
                    domain.EnableRaisingEvents = true;
                    //...you second unblocked watchers
                    second.Changed += new FileSystemEventHandler(Second);
                    second.EnableRaisingEvents = true;
                 }
                 private void Domain(object source, FileSystemEventArgs e)
                 {
                    if (now.Subtract(Static.lastDomain).TotalMilliseconds < minMs)return;
                     //...you code here
                     /* if you need form access
                     this.Invoke(new MethodInvoker(() =>{ textBox1.Text = "...";}));
                     */
                     Static.lastDomain = DateTime.Now;
                 }
                 private void Second(object source, FileSystemEventArgs e)
                 {
                      //...Second rised
                 }
           }
        }
