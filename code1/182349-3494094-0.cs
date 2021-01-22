    private ObservableCollection<MeDepartment> deptitems;
        public ObservableCollection<MeDepartment> DeptItems
        {
            get
            {
                return this.deptitems;
            }
            set
            {
                if (this.deptitems != value)
                {
                    this.deptitems = value;
                }
            }   
        }
        protected ObservableCollection<MeDepartment> deptStaticItems
        {
            get
            {
                return new ObservableCollection<MeDepartment>()
                {
                new MeDepartment{Name = "Department"},
                new MeDepartment{Name = "Select All"}
                };
            }
        }
