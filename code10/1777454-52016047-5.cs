    namespace TreeView_FolderTree
    {
        public partial class GridUserControl : UserControl
        {
     
            public string pathFileData;
     
            public GridUserControl(string pathFileData)
            {
                InitializeComponent();
     
                // Обрабатываем данные
                //Или записываем их в поле
    * *         this.pathFileData = pathFileData;
     
            }
     
            private void GridUserControl_Load(object sender, EventArgs e)
            {
                start_GridUserControl();
            }
     
            public void start_GridUserControl()
            {            
                // dataGridView1
                dataGridView1.DataSource = bs;
                dataGridView1.Columns["DateTime"].DefaultCellStyle.Format = "dd.MM.yyyy HH:mm:ss tt";            
               
            }
     
          
        }
    }
