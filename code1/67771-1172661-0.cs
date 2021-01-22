	public partial class MainForm : Form
	{
		Direct3D Direct3D = new Direct3D();
		Panel slimPanel = new Panel();
		public MainForm()
		{
			InitializeComponent();
			CreateDevice();
			BuildWindows();
		}
		void slimPanel_HandleCreated(object sender, EventArgs e)
		{
			CreateDevice();
		}
		void BuildWindows()
		{
			var listBox = new System.Windows.Controls.ListBox();
			listBox.ItemsSource = Enumerable.Range(0, 100);
			var elementHost = new ElementHost();
			elementHost.Child = listBox;
			elementHost.Dock = DockStyle.Fill;
			Controls.Add(elementHost);
			slimPanel.Dock = DockStyle.Left;
			Controls.Add(slimPanel);
		}
		void CreateDevice()
		{
			PresentParameters presentParams = new PresentParameters();
			presentParams.BackBufferHeight = slimPanel.ClientRectangle.Height;
			presentParams.BackBufferWidth = slimPanel.ClientRectangle.Width;
			presentParams.DeviceWindowHandle = slimPanel.Handle;
			var device = new Device(Direct3D, 0, DeviceType.Hardware, slimPanel.Handle, CreateFlags.HardwareVertexProcessing, presentParams);
		}
	}
