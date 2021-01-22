    protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //bind the list view first
                lvOutput.DataSource = SqlDataSource1;
                lvOutput.DataBind();
                //the first parameter of SetPageProperties is not the page number 
                //it is index of the first record on the page
                //So we need to calculate the index based on the passed in page number.
                int pageNumber = Convert.ToInt32(Request["pageNumber"]);
                int recordNumber = pageNumber * dpPagerTop.PageSize;
                //now set first record
                dpPagerTop.SetPageProperties(recordNumber , 25, false); 
                dpPagerBottom.SetPageProperties(recordNumber , 25, false);
                
                
            }
        }
        protected void lvOutput_PagePropertiesChanged(object sender, EventArgs e)
        {
            lvOutput.DataBind();
        }
