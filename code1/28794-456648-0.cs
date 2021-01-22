    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DataSet ds = new DataSet();
            ds.Tables.Add(new DataTable());
            ds.Tables[0].Columns.Add("id", typeof(int));
            ds.Tables[0].Columns.Add("firstname", typeof(string));
            ds.Tables[0].Columns.Add("lastname", typeof(string));
            ds.Tables[0].Rows.Add(1,"torvalds", "linus");
            ds.Tables[0].Rows.Add(2,"lennon", "john");            
            ds.Tables[0].MergeColumns("name", "lastname", "firstname");
            foreach (DataRow dr in ds.Tables[0].Rows)
                MessageBox.Show(dr["name"].ToString());
        }
        
    }
    public static class Helper
    {
        public static void MergeColumns(this DataTable t, string newColumn, params string[] columnsToMerge)
        {
            t.Columns.Add(newColumn, typeof(string));
            var sb = new StringBuilder();
            sb.Append("{0}, ");
            for (int i = 1; i < columnsToMerge.Length; ++i)
                sb.Append("{" + i.ToString() + "}");
            string format = sb.ToString();
            foreach(DataRow r in t.Rows)
                r[newColumn] = string.Format(format, columnsToMerge.Select(col => r[col]).ToArray() );
        }
    
    }
