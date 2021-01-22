    tableView = new UITableView { 
                Delegate = new TableViewDelegate (this, ConferenceDates), 
                DataSource = new TableViewDataSource (this, ConferenceDates), 
                AutoresizingMask = UIViewAutoresizing.FlexibleHeight | UIViewAutoresizing.FlexibleWidth, 
                BackgroundColor = UIColor.Clear, 
                TableHeaderView = navBar, 
                Frame = new RectangleF (0, 0, this.View.Frame.Width, this.View.Frame.Height) 
            };
	UINavigationController navController = new UINavigationController(tableView);
	navController.ModalTransitionStyle = UIModalTransitionStyle.FlipHorizontal;
	this.PresentModalViewController(navController, true);
