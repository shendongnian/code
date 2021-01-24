        DropDownList budgetDDL1 = new DropDownList();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string QueryString = "SELECT [BudgetCode], [Department], CONCAT([BudgetCode],' - ', [Department]) AS 'textvalue' FROM [tblBudget]";
                using (SqlConnection myConnection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(QueryString, myConnection))
                    {
                        myConnection.Open();
                        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                        DataTable dt = new DataTable();
                        dt.Load(dr);
                        budgetDDL1.SelectedIndex = 0;
                        budgetDDL1.DataSource = dt;
                        budgetDDL1.DataTextField = "textvalue";
                        budgetDDL1.DataValueField = "BudgetCode";
                    }
                }
            }
            budgetDDL1.AutoPostBack = true;
            budgetDDL1.SelectedIndexChanged += budgetDDL1_SelectedIndexChanged;
            budgetDDL1.DataBind();
            table1.Controls.Add(budgetDDL1);
        }
