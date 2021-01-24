    public FacilityViewModel()
    {
        FacilityDataStore facilityDataStore = new FacilityDataStore();
        var items = facilityDataStore.GetList();
        var groupList = new List<FacilitiesGroup>();
        var group = new FacilitiesGroup()
        {
            Heading = "Subscribed"
        };
        foreach( Facility facility in items.Where(x => x.IsSubscribed == true ) )
        {
            group.Add(facility);
        }
        var group2 = new FacilitiesGroup()
        {
            Heading = "Unsubscribed"
        };
        foreach( Facility facility in items.Where(x => x.IsSubscribed == false ) )
        {
            group2.Add(facility);
        }
        groupList.Add(group);
        groupList.Add(group2);
        FacilityList = new ObservableCollection<FacilitiesGroup>(groupList);
    }
