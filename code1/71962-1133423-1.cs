    public class NewLead : Lead
    {
        public bool Insert;
        public NewLead(Lead lead, bool insert)
        {
            Insert = insert;
            foreach (PropertyInfo pi in typeof(Lead).GetProperties())
                GetType().GetProperty(pi.Name).SetValue
                   (this, pi.GetValue(lead,null), null);
        }
    }
