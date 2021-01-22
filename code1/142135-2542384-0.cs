	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			// watch the disposed event....
			backgroundWorker1.Disposed += new EventHandler(backgroundWorker1_Disposed);
			
			// try with and without the following lines
			components = new Container();
			components.Add(backgroundWorker1);
		}
		void backgroundWorker1_Disposed(object sender, EventArgs e)
		{
			Debug.WriteLine("backgroundWorker1_Disposed");
		}
	//... from the Designer.xyz file ...
	
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}
	}
