    public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}
		private void button1_Click(object sender, EventArgs e)
		{
			Foo f = new Foo();
			f.BarList = new List<Bar>();
			f.BarList.Add(new Bar { Property1 = "abc", Property2 = "def" });
			XmlSerializer ser = new XmlSerializer(typeof(Foo));
			using (FileStream fs = new FileStream(@"c:\sertest.xml", FileMode.Create))
			{
				ser.Serialize(fs, f);
			}
		}
	}
	public class Foo
	{
		[XmlArray("BarList"), XmlArrayItem(typeof(Bar), ElementName = "Bar")]
		public List<Bar> BarList { get; set; }
	}
	[XmlRoot("Foo")]
	public class Bar
	{
		public string Property1 { get; set; }
		public string Property2 { get; set; }
	}
