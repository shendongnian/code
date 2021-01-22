            if (!IsPostBack)
            {
                List<YourTable> table= new List<YourTable>();
                YourtableRepository tableRepo = new YourtableRepository();
                
                int conuntryInfoID=1;
                table= tableRepo.GetAllDataByID(ID);
                
                ddlYourTable.DataSource = stateInfo;
                ddlYourTable.DataTextField = "Your_ColumnName";
                ddlYourTable.DataValueField = "ID";
                ddlYourTable.DataBind();
                
                
            }
        }
