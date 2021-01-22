        #region Model
        
        private string _username;
        private string _userpassword;
        private string _useremail;
        private int _userid;
        /// <summary>
        /// 
        /// </summary>
        public int userid
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string username
        {
            set { _username = value; }
            get { return _username; }
        }
        
        /// <summary>
        /// 
        /// </summary>
        public string useremail
        {
            set { _useremail = value; }
            get { return _useremail; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string userpassword
        {
            set { _userpassword = value; }
            get { return _userpassword; }
        }
        #endregion Model
    }
    public List<ModelUser> DataTableToList(DataTable dt)
    {
        List<ModelUser> modelList = new List<ModelUser>();
        int rowsCount = dt.Rows.Count;
        if (rowsCount > 0)
        {
            ModelUser model;
            for (int n = 0; n < rowsCount; n++)
            {
                model = new ModelUser();
                model.userid = (int)dt.Rows[n]["userid"];
                model.username = dt.Rows[n]["username"].ToString();
                model.useremail = dt.Rows[n]["useremail"].ToString();
                model.userpassword = dt.Rows[n]["userpassword"].ToString();
                modelList.Add(model);
            }
        }
        return modelList;
    }
    static DataTable GetTable()
    {
        // Here we create a DataTable with four columns.
        DataTable table = new DataTable();
        table.Columns.Add("userid", typeof(int));
        table.Columns.Add("username", typeof(string));
        table.Columns.Add("useremail", typeof(string));
        table.Columns.Add("userpassword", typeof(string));
        // Here we add five DataRows.
        table.Rows.Add(25, "Jame", "Jame@hotmail.com", DateTime.Now.ToString());
        table.Rows.Add(50, "luci", "luci@hotmail.com", DateTime.Now.ToString());
        table.Rows.Add(10, "Andrey", "Andrey@hotmail.com", DateTime.Now.ToString());
        table.Rows.Add(21, "Michael", "Michael@hotmail.com", DateTime.Now.ToString());
        table.Rows.Add(100, "Steven", "Steven@hotmail.com", DateTime.Now.ToString());
        return table;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        List<ModelUser> userList = new List<ModelUser>();
        DataTable dt = GetTable();
        userList = DataTableToList(dt);
        gv.DataSource = userList;
        gv.DataBind();
    }[enter image description here][1]
