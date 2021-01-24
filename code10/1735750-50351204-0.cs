    public DestEntity(IEnumerable<object> list1, IEnumerable<object> list2)
    {
        this.DestinationObjects = new List<SubDestinationEntity>();
        if (list1.Any())
        {
            this.DestinationObjects.Add(new SubDestinationEntity
            {
                Title = "Some text 1",
                Objects = list1
            });
        }
        if (list2.Any())
        {
            this.DestinationObjects.Add(new SubDestinationEntity
            {
                Title = "Some text 2",
                Objects = list2
            });
        }
    }
