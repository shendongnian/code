    public Visibility AdministratorVisibility
    {
        get 
        { 
            MyPrincipal.CurrentPrincipal.IsInRole("Administrator") ? Visibility.Hidden : Visibility.Visible; 
        }
    }
