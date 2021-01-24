    If (!Page.IsPostBack)
    {
       List<GroceryBranch> allGroceryBranches = GetAllGroceryBranchesFromDB();
       DropDownList1.Items.Clear();
       DropDownList1.Items.AddRange(allGroceryBranches
        .Select(b=> new ListItem(b.Grocery_Branch_Name, b.Grocery_Branch_No))
    }
