         protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {  
            ((DropDownList)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("RoleDropDownList")).DataSource = Roles.GetAllRoles(); 
            ((DropDownList)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("RoleDropDownList")).DataBind( );  
            int rolecounter = ((DropDownList)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("RoleDropDownList")).Items.Count; 
            ((DropDownList)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("RoleDropDownList")).Items[rolecounter - rolecounter].Selected = true;     
        }
    }
    protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
    {
        DropDownList roleDropDownList = (DropDownList)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("RoleDropDownList");
        Roles.AddUserToRole(CreateUserWizard1.UserName, roleDropDownList.SelectedValue);
    }
