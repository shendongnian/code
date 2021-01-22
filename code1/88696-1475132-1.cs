public PersistenceStatePresenter(IPersistenceStateView view)
{
    _view = view;
    
    _view.Save += (sender, e) => this.Save();
    _view.Open += (sender, e) => this.Open();
   // etc.
   InitializeModel();
   InitializeView();
}
