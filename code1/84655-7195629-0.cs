	public partial class Form1 : Form
	{
		System.Timers.Timer T = new System.Timers.Timer();
		public Form1()
		{
			InitializeComponent();
			T.Elapsed += new ElapsedEventHandler(T_Elapsed);
                        T.SynchronizingObject = this;
			T.Start();
		}
    
		void T_Elapsed(object sender, ElapsedEventArgs e)
		{
			label1.Text = "This will not work";
		}
	}
