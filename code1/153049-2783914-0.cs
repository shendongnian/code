    public partial class Form1 : Form
    {
        private SynchronizationContext c;
        private Thread t;
        private EventWaitHandle pause =
            new EventWaitHandle(false, EventResetMode.ManualReset);
    
        public Form1()
        {
            this.InitializeComponent();
            this.c = SynchronizationContext.Current;
        }
    
        private void Form1Activated(object sender, EventArgs e)
        {
            this.t = new Thread(new ThreadStart(delegate
            {
                this.pause.Reset();
                while (this.t.IsAlive && !this.pause.WaitOne(1000))
                {
                    this.c.Post(
                        state => this.label1.Text = DateTime.Now.ToString(),
                        null);
                }
            }));
            this.t.IsBackground = true;
            this.t.Start();
        }
    
        private void Form1Deactivate(object sender, EventArgs e)
        {
            this.pause.Set();
            this.t.Join();
        }
    
        /// <summary>
        /// Button1s the click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void Button1Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
