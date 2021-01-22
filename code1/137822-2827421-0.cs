        Button SaveButton;
    }
    // View code behind
    public Button SaveButton
    {
       get { return btnSave; }
    }
    
    //  Presenter
    internal Presenter(IView view,IRepository repository)
    {
       _view = view;
       _repository = repository;
       view.SaveButton.Click += new EventHandler(Saved);;
    }
    void Saved(object sender, EventArgs e)
    {
       // do save
    }
