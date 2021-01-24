    public class CompanyByStatusList : ObservableCollection<Company>
    {
        public string Status { get; set; }
        public ObservableCollection<Company> Companies => this;
    }
