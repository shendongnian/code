        const string devMachine = @"Data Source=C:\_DEVELOPMENT\__.NET\dotNetSnippets\Mine\TestSqlite\test.s3db";
        SQLiteConnection c = new SQLiteConnection(devMachine);
        SQLiteDataAdapter da = new SQLiteDataAdapter();
        DataTable dt = new DataTable();
        public Form1()
        {
            InitializeComponent();
           
            da = new SQLiteDataAdapter("select product_id, product_name, abbrev from product", c);
            var b = new SQLiteCommandBuilder(da);
            da.InsertCommand = new SQLiteCommand(
                @"insert into product(product_id, product_name, abbrev) values(:_product_id, :_product_name, :_abbrev);
                select product_id /* include rowversion field here if you need */ 
                from product where product_id = LAST_INSERT_ROWID();", c);
            da.InsertCommand.Parameters.Add("_product_id", DbType.Int32,0,"product_id");
            da.InsertCommand.Parameters.Add("_product_name", DbType.String, 0, "product_name");
            da.InsertCommand.Parameters.Add("_abbrev", DbType.String, 0, "abbrev");
            da.InsertCommand.UpdatedRowSource = UpdateRowSource.FirstReturnedRecord;
            da.UpdateCommand = b.GetUpdateCommand();
            da.DeleteCommand = b.GetDeleteCommand();
                        
            da.Fill(dt);
            bds.DataSource = dt;
            grd.DataSource = bds;
        }
        private void uxUpdate_Click(object sender, EventArgs e)
        {
            da.Update(dt);
        }
