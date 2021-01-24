    public object GrouppedTitleProperties
        {
            get => from tp in this.TitleProperties
                   group tp by tp.GroupingParameter into GrouppedTitleProperties
                   select new
                   {
                       Key = GrouppedTitleProperties.Key,
                       Items = GrouppedTitleProperties.ToList()
                   };
        }
