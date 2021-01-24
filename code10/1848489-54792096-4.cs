	using System.Data;
	using System.Drawing;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using System.Windows.Forms;
	using System.IO;
	namespace ProvaSalvataggioFile2
	{
		public partial class MainForm : Form
		{
			private readonly OpenFile openFile = new OpenFile();
			public MainForm()
			{
				InitializeComponent();
			}
			private void btnSave_Click(object sender, EventArgs e)
			{
				string inputString = tbInputText.Text;
				if (inputString.IsValidString())
				{
					inputString.SaveToFile();
				}
				else
				{
					MessageBox.Show("The input string is not valid: please insert a valid string",
						"Empty or null input string",
						MessageBoxButtons.OK,
						MessageBoxIcon.Exclamation);
					tbInputText.Focus();
				}
			}
			private void btnOpenFile_Click(object sender, EventArgs e)
			{
				RefreshTextFile();
			}
			private void btnUpdate_Click(object sender, EventArgs e)
			{
				RefreshTextFile();
			}
			
			private void RefreshTextFile()
			{
				TextFile textFile = openFile.OpenTextFile();
				tbFileText.Text = textFile.Contents;
			}
		}
	}
