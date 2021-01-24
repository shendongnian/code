    public partial class Form1 : Form
    {
    public Form1()
    {
        InitializeComponent();
    }
    private ExcelClass ex = null; //create your member field here
    public void OpenFile()
    {
        ex = new ExcelClass(@"C:\path\TestBook.xlsx", 1);
    }
    private void OpenWorkbook_Click(object sender, EventArgs e)
    {
      OpenFile();
    }
    private void ReadCell_Click(object sender, EventArgs e)
    {
        if (ex!= null) {
            ex.ReadCell();
        } else {
            //do nothing, or inform user they have to press other button to open the file
        }
    }
