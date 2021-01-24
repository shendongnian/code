    public class CompanyVm
    {
        public string Name { set; get; }
        public IEnumerable<ContactVm> Contacts { set;get;}
    }
    public class ContactVm
    {
        public string Name { set; get; }
    }
    public class ViewModelDemoVM 
    {
        public List<CompanyVm> Companies { set; get; }
    }
