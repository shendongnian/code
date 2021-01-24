    public override void ViewDidLoad()
    {
        base.ViewDidLoad();
        
        MyTableView.RegisterNibForCellReuse(UINib.FromName(nameof(ExperienceCell), NSBundle.MainBundle), "cell_id");
        MyTableView.Source = new ExperienceSource(..., ...);    
        // .. your code
    }
