    public ObservableCollection<object> Items { get; set; } = new ObservableCollection<object>
        {
          new {Name="Item 1", SubItems= new List<int>{11,22,33,44 } },
          new {Name="Item 2", SubItems= new List<int>{11,22,33,44 } },
          new {Name="Item 3", SubItems= new List<int>{11,22,33,44 } },
        };
