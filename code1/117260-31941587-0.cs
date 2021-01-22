    public MyForm : Form
    {
        ...
        public bool CanDelete
        { 
            get { return deleteToolStripButton.Enabled; }
            set { deleteToolStripButton.Enabled = value; }
        }
        public MyForm()
        {
            ...
            this.DataBindings.Add("CanDelete", this.MyModel, "DeleteAllowed",
                                  false, DataSourceUpdateMode.Never);
            ...
        }
    }
