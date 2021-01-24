    public EvaluationViewModel()
    {
        Evaluations = new ObservableCollection<Evaluation>();
        TestView = (CollectionView)new CollectionViewSource { Source = Evaluations }.View;
        TestView.SortDescriptions.Add(new SortDescription("TestDate", ListSortDirection.Ascending));
    }
    
    public ObservableCollection<Evaluation> Evaluations { get; }
    public CollectionView TestView { get; set; }
