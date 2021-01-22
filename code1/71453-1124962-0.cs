        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                this.DataBind();
            }
        }
        protected void MyButton_Click(object sender, EventArgs e)
        {
            //Code to do stuff here...
            //Re DataBind
            this.DataBind();
        }
        public override void DataBind()
        {
            //Databinding logic here
        }
