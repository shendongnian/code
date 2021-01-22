    public partial class Form1 : Form
    {
    public Form1()
    {
      InitializeComponent();
    }
    private class Thing
    {
      public String Letters { get; set; }
      public Int32 Id { get; set; }
    }
    private void Form1_Load(object sender, EventArgs e)
    {
      List<Thing> data = new List<Thing>();
      for (int i = 0; i < 50; i++)
      {
        Thing temp = new Thing();
        temp.Letters = "abc " + i.ToString();
        temp.Id = i;
        data.Add(temp);
      }
      listBox1.DataSource = data;
      listBox1.DisplayMember = "Letters";
      listBox1.ValueMember = "Id";
      List<Thing> data2 = new List<Thing>();
      for (int i = 0; i < 50; i++)
      {
        Thing temp = new Thing();
        temp.Letters = "abc " + i.ToString();
        temp.Id = i;
        data2.Add(temp);
      }
      listBox2.DataSource = data2;
      listBox2.DisplayMember = "Letters";
      listBox2.ValueMember = "Id";
    }
  }
