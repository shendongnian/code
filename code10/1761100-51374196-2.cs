        ObservableCollection<Member> member = new ObservableCollection<Member>();
        ObservableCollection<Member> mainPanelMembers = new ObservableCollection<Member>();
        public MainWindow()
        {
            InitializeComponent();
            member.Add(new Member { Name = "Karthick", ID = "20011", Address = "10, MainRoad, Chennai" });
            member.Add(new Member { Name = "Suresh", ID = "20012", Address = "11, MainRoad, Madurai" });
            member.Add(new Member { Name = "Arun", ID = "20013", Address = "12, MainRoad, Selam" });
            member.Add(new Member { Name = "Gokul", ID = "20014", Address = "13, MainRoad, Coimbature" });
            member.Add(new Member { Name = "Vishnu", ID = "20015", Address = "14, MainRoad, Goa" });
            memberCollection.DataContext = member;
            mainPanel.DataContext = mainPanelMembers;
        }
