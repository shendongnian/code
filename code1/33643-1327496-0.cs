    public partial class Form1 : Form
    {
      public Form1()
       {
        InitializeComponent();
        }
      private Excel.Application excelApp = null;
      private void button1_Click(object sender, EventArgs e)
       {
        excelApp.get_Range("A1:A360,B1:E1", Type.Missing).Merge(Type.Missing);
       }
      private void Form1_Load(object sender, EventArgs e)
       {
        excelApp = Marshal.GetActiveObject("Excel.Application") as Excel.Application ;
       }
    }
