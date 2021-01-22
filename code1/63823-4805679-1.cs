    public int EditIndexComposition;
    protected void ItemEditing(object sender, ListViewEditEventArgs e)
            {
                C_LV_MyObjects.EditIndex = e.NewEditIndex;
                C_LV_MyObjects.DataBind();
            }
    
            protected void MyObjectEditing(object sender, EventArgs e)
            {
                ListViewEditEventArgs MyEvent = (ListViewEditEventArgs)e;
                if (MyEvent != null)
                    EditIndexComposition= MyEvent.NewEditIndex;
    
                C_LV_MyObjects.DataBind();
                
            }
    
            protected void DataBoundMyObjects(object sender, ListViewItemEventArgs e)
            {
                MyUC uc = (MyUC)e.Item.FindControl("C_UC_MyUserControl");
    
                if (uc!=null)
                {
                    uc.EditIndex = EditIndexComposition;
                    ListViewDataItem dataItem = (ListViewDataItem)e.Item;
                    MyObject obj= (MyObject)dataItem.DataItem;
                    uc.DataSource=Myservice.GetDatasource(obj.Id);
                    uc.DataBind();
                    
                }
            }
