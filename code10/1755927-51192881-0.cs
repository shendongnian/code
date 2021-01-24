	namespace WindowsFormsApp1
	{
		public partial class @new : UserControl
		{
			private static @new _instance;
			public static @new Instance
			{
				get
				{
					if (_instance == null)
						_instance = new @new();
					return _instance;
				}
			}
			
			public event EventHandler StepCompleted;
			public @new()
			{
				InitializeComponent();
			}
			private void choice_button_Click(object sender, EventArgs e)
			{
				StepCompleted?.Invoke(this, EventArgs.Empty);
			}
		}
	}
