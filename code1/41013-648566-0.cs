    public Form1()
    {
        InitializeComponent();
    
        dataGridView1.DataSource = new List<MyObject>
        {
            new MyObject{ MyDateTime= DateTime.Now }
        };
    
        dataGridView1.Columns["MyDateTime"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
    }
    public class MyObject
    {
        public DateTime MyDateTime { get; set; }
    }
