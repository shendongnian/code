    namespace WindowsFormsApplication7
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                var dt = new DataTable();
                dt.Columns.Add("lastname", typeof(string));
                dt.Columns.Add("firstname", typeof(string));
                dt.Rows.Add("lennon", "john");
                dt.Rows.Add("mccartney", "paul");
                
                var ms = new MemoryStream();
                var bf = new BinaryFormatter();
                bf.Serialize(ms, dt);
                byte[] bytes = ms.ToArray();
                var bfx = new BinaryFormatter();
                var msx = new MemoryStream();
                msx.Write(bytes, 0, bytes.Length);
                msx.Seek(0, 0);
                // doesn't just copy reference, copy all contents
                var dtx = (DataTable)bfx.Deserialize(msx);
                
                dtx.Rows[0]["lastname"] = "Ono";
                // just copy reference
                var dty = dt;
                dty.Rows[0]["lastname"] = "Winston";
                MessageBox.Show(dt.Rows[0]["lastname"].ToString()); // Winston
                MessageBox.Show(dtx.Rows[0]["lastname"].ToString()); // Ono
                MessageBox.Show(dty.Rows[0]["lastname"].ToString()); // Winston
        
            }
        }
    }
