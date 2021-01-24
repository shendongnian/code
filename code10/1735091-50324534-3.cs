    public partial class MainWindow : Window
    {
    	public int globalServo = 21;
    
    	public MainWindow()
    	{
    		InitializeComponent();
    
    		List<MyData> lstMyData = new List<MyData>();
    
    		for (int i = 1; i < 6; i++)
    		{
    			List<MySubData> lstMySubData = new List<MySubData>();
    
    			for (int j = 0; j < globalServo; j++)
    			{
    				lstMySubData.Add(new MySubData() { LED = "LED" + j, Servo = "Servo" + j });
    			}
    
    			lstMyData.Add(new MyData()
    			{
    				id = i,
    				name = "name-" + i,
    				selected = Convert.ToBoolean(i % 2),
    				lstSubData = lstMySubData
    			});
    		}
    
    		lvData.View = GenerateGridView();
    		lvData.ItemsSource = GenerateSource(lstMyData).DefaultView;
    	}
    
    	private GridView GenerateGridView()
    	{
    		GridView view = new GridView();
    
    		view.Columns.Add(new GridViewColumn() { Header = "Id", DisplayMemberBinding = new Binding("Id") });
    		view.Columns.Add(new GridViewColumn() { Header = "Name", DisplayMemberBinding = new Binding("Name") });
    		view.Columns.Add(new GridViewColumn() { Header = "Selected", CellTemplate = GetCheckboxTemplate() });
    
    		for (int i = 1; i <= globalServo; i++)
    		{
    			view.Columns.Add(new GridViewColumn() { Header = "Servo" + i, CellTemplate = GetTextBlockTemplate(i) });
    		}
    
    		return view;
    	}
    
    	private DataTable GenerateSource(List<MyData> dataList)
    	{
    		DataTable dt = new DataTable();
    		dt.Columns.Add("Id");
    		dt.Columns.Add("Name");
    		dt.Columns.Add("Selected");
    
    		for (int i = 1; i <= globalServo; i++)
    		{
    			dt.Columns.Add("Servo" + i);
    		}
    
    		foreach (var item in dataList)
    		{
    			DataRow row = dt.NewRow();
    			row["Id"] = item.id;
    			row["Name"] = item.name;
    			row["Selected"] = item.selected;
    
    			for (int i = 1; i <= globalServo; i++)
    			{
    				row["Servo" + i] = item.lstSubData[i - 1].Servo + "##" + item.lstSubData[i - 1].LED;
    			}
    
    			dt.Rows.Add(row);
    		}
    
    		return dt;
    	}
    
    	private DataTemplate GetCheckboxTemplate()
    	{
    		DataTemplate dt = new DataTemplate(typeof(CheckBox));
    		FrameworkElementFactory chkElement = new FrameworkElementFactory(typeof(CheckBox));
    		dt.VisualTree = chkElement;
    
    		Binding bind = new Binding();
    		bind.Path = new PropertyPath("Selected");
    		chkElement.SetBinding(CheckBox.IsCheckedProperty, bind);
    
    		return dt;
    	}
    
    	private DataTemplate GetTextBlockTemplate(int Index)
    	{
    		TextConverter textConverter = new TextConverter();
    		ColorConverter colorConverter = new ColorConverter();
    
    		DataTemplate dt = new DataTemplate(typeof(TextBlock));
    		FrameworkElementFactory txtElement = new FrameworkElementFactory(typeof(TextBlock));
    		dt.VisualTree = txtElement;
    
    		Binding bind = new Binding();
    		bind.Path = new PropertyPath("Servo" + Index);
    		bind.Converter = textConverter;
    		txtElement.SetBinding(TextBlock.TextProperty, bind);
    
    		Binding bind1 = new Binding();
    		bind1.Path = new PropertyPath("Servo" + Index);
    		bind1.Converter = colorConverter;
    		txtElement.SetBinding(TextBlock.BackgroundProperty, bind1);
    
    		return dt;
    	}
    
    }
