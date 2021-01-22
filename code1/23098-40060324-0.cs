     public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Thread t, t2, t3;
        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
             t = new Thread(birinicBar); //evry thread workes with a new progressBar
            
             t2 = new Thread(ikinciBar);
            
             t3 = new Thread(ucuncuBar);
            
        }
        public void birinicBar() //to make progressBar work
        {
            for (int i = 0; i < 100; i++) {
                progressBar1.Value++;
                Thread.Sleep(100); // this progressBar gonna work faster
            }
        }
        public void ikinciBar()
        {
            for (int i = 0; i < 100; i++)
            {
                progressBar2.Value++;
                Thread.Sleep(200);
            }
          
        }
        public void ucuncuBar()
        {
            for (int i = 0; i < 100; i++)
            {
                progressBar3.Value++;
                Thread.Sleep(300);
            }
        }
        private void button1_Click(object sender, EventArgs e) //that button to start the threads
        {
            t.Start();
            t2.Start(); t3.Start();
            
        }
        private void button4_Click(object sender, EventArgs e)//that button to stup the threads with the progressBar
        {
            t.Suspend();
            t2.Suspend();
            t3.Suspend();
        }
        private void button2_Click(object sender, EventArgs e)// that is for contuniue after stuping
        {
            t.Resume();
            t2.Resume();
            t3.Resume();
        }
        private void button3_Click(object sender, EventArgs e) // finally with that button you can remove all of the threads
        {
            t.Abort();
            t2.Abort();
            t3.Abort();
        }
    }
