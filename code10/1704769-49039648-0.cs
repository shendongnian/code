    protected async override void OnNavigatingFrom(NavigatingCancelEventArgs e)
    { 
        //if navigation is forced, skip all logic
        if ( !forceNavigation )
        {
            var navigableViewModel = this.DataContext as INavigable;
            if (navigableViewModel != null)
            {
                e.Cancel = true;
                //display the dialog to the user, if he says yes, set
                //forceNavigation = true; and repeat the navigation (e.g. GoBack, ... )
            }
        }
    }
