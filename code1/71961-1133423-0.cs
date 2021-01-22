    public class NewLead: Lead
    {
        public bool Insert;
        public NewLead(Lead lead, bool insert):base()
        {
            Insert = insert;
            foreach(FieldInfo fi in typeof(Lead ).GetFields())
                GetType().GetField(fi.Name).SetValue
                   (GetType().GetField(fi.Name), fi.GetValue(t));
        }
    }
