    public List<int> Data
        {
            get
            {
                if (ViewState["Data"] == null)
                {
                    // Get your data, save it and return it.
                    var data = new List<int> { 1, 2, 3 };
                    ViewState["Data"] = data;
                    return data;
                }
                    return (List<int>)ViewState["Data"];
            }
            set
            {
                ViewState["Data"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { 
                BindData(Data); 
            }
        }
    
        private void BindData(List<int> data)
        {
            _ddlOptions.DataSource = data;
            _ddlOptions.DataBind();
        }
    
        protected void OnAdd(object sender, EventArgs e)
        {
            var existing = Data;
    
            existing.Add(_ddlOptions.SelectedItem);                        
            _ddlOptions.Items.RemoveAt(_ddlOptions.SelectedIndex);
    
            Data = existing;
            BindData(existing);
        }
