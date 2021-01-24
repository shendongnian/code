	using System.Windows.Forms;
	namespace CallOtherClassMethod
	{
		public partial class MainPage : Form
		{
			public MainPage()
			{
				InitializeComponent();
			}
			private void ObjButton_Click(object sender, System.EventArgs e)
			{
				Shelf objShelf = new Shelf();
				objTextBox.Text = objShelf.ShelfMethod();
			}
		}
	}
	
