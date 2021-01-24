    public RoundsViewModel()
    {
        _rounds = CreateSampleData();
    }
    
    private ObservableCollection<Round> CreateSampleData()
    {
        ObservableCollection<Round> dummyData = new ObservableCollection<Round>();
    
        dummyData.Add(new Round() { Name="User", handicap=1, PlayedUTC=DateTime.Now });
        dummyData.Add(new Round() { Name="User", handicap=1, PlayedUTC=DateTime.Now });
        dummyData.Add(new Round() { Name="User", handicap=1, PlayedUTC=DateTime.Now });
    
        return dummyData;
    }
