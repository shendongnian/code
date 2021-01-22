    protected void Page_Load(object sender, EventArgs e)
        {
            fileUpload.UploadPage += "?id=6";
            if (!Page.IsPostBack)
            {
                DataSet ds = new DataSet();
                DataTable dt = ds.Tables.Add("Customer");
                dt.Columns.Add("CustomerName", Type.GetType("System.String"));
                dt.Columns.Add("Country", Type.GetType("System.String"));
                DataRow dr = dt.NewRow();
                dr[0] = "Testcustomer1";
                dr[1] = "USA";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr[0] = "Testcustomer2";
                dr[1] = "UK";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr[0] = "Testcustomer3";
                dr[1] = "GERMANY";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr[0] = "Testcustomer4";
                dr[1] = "FRANCE";
                dt.Rows.Add(dr);
                //Bind the data to the Repeater
                Repeater1.DataSource = ds;
                Repeater1.DataMember = "Customer";
                Repeater1.DataBind();
            }
        }
        protected void SubmitMessage_Click(object sender, EventArgs e)
        {
            Label MyLabel = (Label)Repeater1.Items[0].FindControl("Label1");
            Label MyLabel2 = (Label)Repeater1.Items[0].FindControl("Label2");
            //Empty String Text was never set server side
            Label3.Text = MyLabel.Text;
            //String is found because Text was set
            Label4.Text = MyLabel2.Text;
        }
