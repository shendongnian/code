    public class MyType
    {
        public string Name { get; set; }
        public Image Image { get; set; }
    }
    ...
    [STAThread]
    static void Main()
    {
        List<MyType> list = new List<MyType>();
        list.Add(new MyType { Image=Bitmap.FromFile(image1Path), Name="Fred" });
        list.Add(new MyType { Image=Bitmap.FromFile(image2Path), Name="Barney" });
        DataTable table = list.ToDataTable();
        BindingSource bs = new BindingSource(table, "");
        bs.Filter = @"Name = 'Fred'";
        Application.Run(new Form {
            Controls = {
                new DataGridView {
                    DataSource = bs,
                    Dock = DockStyle.Fill}
            }
        });
    }
