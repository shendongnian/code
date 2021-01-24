    private List<Dog> Dogs = new List<Dog>();
    private List<Cat> Cats = new List<Cat>();
    private List<Bird> Birds = new List<Bird>();
    public MainWindowViewModel()
    {
        Animals = new ObservableCollection<ObservableCollection<Animal>>();
        Animals.Add(new ObservableCollection<Animal>(Cats));
        Animals.Add(new ObservableCollection<Animal>(Dogs));
        Animals.Add(new ObservableCollection<Animal>(Birds));
    }
    public ObservableCollection<ObservableCollection<Animal>> Animals { get; set; }
