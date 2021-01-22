    public int BranchValue {get;set;}
    public string BranchText {get;set;}
...
    public List<Branch> branchesToShow { get; private set; }
    ...                           
    branchesToShow = getBranch(user.code); //get the list of branches
    ddlOption.DataTextField = "BranchText"
    ddlOption.DataValueField = "BranchValue";
    ddlOption.DataSource = branchesToShow;                        
    ddlOption.DataBind();
