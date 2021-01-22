    public partial class Form1 : Form {
		private readonly ContainerMessageFilter containerMessageFilter;
		public Form1() {
			InitializeComponent();
			containerMessageFilter = new ContainerMessageFilter( panel1 );
			containerMessageFilter.MouseEnter += ContainerMessageFilter_MouseEnter;
			containerMessageFilter.MouseLeave += ContainerMessageFilter_MouseLeave;
			Application.AddMessageFilter( containerMessageFilter );
		}
		private static void ContainerMessageFilter_MouseLeave( object sender, EventArgs e ) {
			Console.WriteLine( "Leave" );
		}
		private static void ContainerMessageFilter_MouseEnter( object sender, EventArgs e ) {
			Console.WriteLine( "Enter" );
		}
		private void Form1_FormClosed( object sender, FormClosedEventArgs e ) {
			Application.RemoveMessageFilter( containerMessageFilter );
		}
	}
 
