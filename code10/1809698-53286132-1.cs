    public class ListItemConverter : TypeConverter
    {
        private List<ListItem> languages;
        public ListItemConverter()
        {
            // Initializes the standard values list with defaults.
            languages = new List<ListItem>();
            foreach (CultureInfo ci in CultureInfo.GetCultures(CultureTypes.AllCultures))
            {
                languages.Add(new ListItem(ci.DisplayName, ci.Name));
            }
        } 
        // Indicates this type converter provides a list of standard values.
        public override bool GetStandardValuesSupported(System.ComponentModel.ITypeDescriptorContext context)
        {
            return true;
        } 
                
        public override StandardValuesCollection GetStandardValues(System.ComponentModel.ITypeDescriptorContext context)
        {
            // Passes the local array.
            StandardValuesCollection svc = new StandardValuesCollection(languages);
            return svc;
        } 
        public override bool CanConvertFrom(ITypeDescriptorContext context, 
                                              System.Type sourceType)
        {
            if (sourceType == typeof(string))
            {
                // where the debug code goes
                return true;
            }
            else
                return base.CanConvertFrom(context, sourceType);
        } 
        // ADDED: the list is exclusive - no new entries allowed
        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if(value is string)
            {
                ListItem item = (ListItem)languages.
                            FirstOrDefault( q => (string.Compare(q.Name, value.ToString(),true) == 0));
                return item;
            }
            else
                return base.ConvertFrom(context, culture, value);
        }
    }
