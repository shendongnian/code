    class Record
    {
        public object Display { get; set; }
        public object Value { get; set; }
    }
    IEnumerable<Object> source { get; set; }
    String ValueMember { get; set; }
    String DisplayMember { get; set; }
    String FilterMember { get; set; }
    Object DataSelect(Object criterium)
    {
        List<Record> result = new List<Record>();
        foreach (var record in source) Parse(sender, record, criterium, result);
        return result;
    }
    private void Parse(object record, Object criterium, List<Record> result)
    {
        MethodInfo DisplayGetter = null;
        MethodInfo ValueGetter = null;
        bool AddRecord = false;
        foreach (PropertyInfo property in record.GetType().GetProperties())
        {
            if (property.Name == DisplayMember) DisplayGetter = property.GetGetMethod();
            else if (property.Name == ValueMember) ValueGetter = property.GetGetMethod();
            else if (property.Name == FilterMember)
            {
                MethodInfo ExternalGetter = property.GetGetMethod();
                if (ExternalGetter == null) break;
                else
                {
                    object external = ExternalGetter.Invoke(record, new object[] { });
                    AddRecord = external.Equals(criterium);
                    if (!AddRecord) break;
                }
            }
            if (AddRecord && (DisplayGetter != null) && (ValueGetter != null)) break;
        }
        if (AddRecord && (DisplayGetter != null) && (ValueGetter != null))
        {
            Record r = new Record();
            r.Display = (DisplayGetter != null) 
                ? DisplayGetter.Invoke(record, new object[] { })
                : null;
            r.Value = (ValueGetter != null) 
                ? ValueGetter.Invoke(record, new object[] { })
                : null;
            result.Add(r);
        }
    }
