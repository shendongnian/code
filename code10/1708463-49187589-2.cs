    public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            entities = new List<SampleEntity>()
            {
                new SampleEntity() { Id = 1, Description = "Test 1", IsViewPermission = true, IsIssuePermission = true, IsActive = true },
                new SampleEntity() { Id = 2, Description = "Test 2", IsViewPermission = true, IsIssuePermission = true, IsActive = true },
                new SampleEntity() { Id = 3, Description = "Test 3", IsViewPermission = true, IsIssuePermission = true, IsActive = true },
                new SampleEntity() { Id = 4, Description = "Test 4", IsViewPermission = true, IsIssuePermission = true, IsActive = true },
                new SampleEntity() { Id = 5, Description = "Test 5", IsViewPermission = true, IsIssuePermission = true, IsActive = true },
                new SampleEntity() { Id = 6, Description = "Test 6", IsViewPermission = true, IsIssuePermission = true, IsActive = true },
                new SampleEntity() { Id = 7, Description = "Test 7", IsViewPermission = true, IsIssuePermission = true, IsActive = true },
                new SampleEntity() { Id = 8, Description = "Test 8", IsViewPermission = true, IsIssuePermission = true, IsActive = true }
            };
            dgMainGrid.ItemsSource = entities;
            tempEntities = new List<SampleEntity>();
            entities.ForEach(item => 
            {
                SampleEntity newEntity = new SampleEntity()
                {
                    Id = item.Id,
                    Description = item.Description,
                    IsViewPermission = item.IsViewPermission,
                    IsIssuePermission = item.IsIssuePermission,
                    IsActive = item.IsActive
                };
                tempEntities.Add(newEntity);
            });                
        }
