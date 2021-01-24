    namespace WpfApp1
    {
	public partial class MainWindow : Window
	 {
	  public MainWindow()
		{
			InitializeComponent();
			var x = new VM();
			x.Items.Add(new Class2 { IMAGE_PATH = "dir_16p.png", value = "123" });
			x.Items.Add(new Class2 { IMAGE_PATH = "dir_blue_16p.png", value = "456" });
			DataContext = x;
			dg1.Columns.Add(Class1.createImageColumn("test", new Size(16, 16)));
			dg1.Columns.Add(new DataGridTextColumn { Binding = new Binding("value"), 
            Header = "Value" });
		}
	  }
    }
