    protected void populateDropDownList(){
       IList<MyObject> myObjectList = getMyObjectList();
       
       DropDownList1.DataSource = myObjectList;
       DropDownList1.DataTextField = "FullName"; // exact name of field in class
       DropDownList.DataValueField = "id";
       
       DropDownList.DataBind();
    
    }
