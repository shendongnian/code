    public class FieldList
    {
        public List<Field> fields { get; set; }
    }
    public class Field
    {
        public bool webhook { get; set; }
        public object associated_lookup { get; set; }
        public string json_type { get; set; }
        public object crypt { get; set; }
        public string field_label { get; set; }
        public object tooltip { get; set; }
        public string created_source { get; set; }
        public bool field_read_only { get; set; }
        public int section_id { get; set; }
        public bool read_only { get; set; }
        public bool businesscard_supported { get; set; }
        public Currency currency { get; set; }
        public string id { get; set; }
        public bool custom_field { get; set; }
        public Lookup lookup { get; set; }
        public bool visible { get; set; }
        public int length { get; set; }
        public ViewType view_type { get; set; }
        public object subform { get; set; }
        public string api_name { get; set; }
        public Unique unique { get; set; }
        public string data_type { get; set; }
        public Formula formula { get; set; }
        public object decimal_place { get; set; }
        public List<PickListValues> pick_list_values { get; set; }
        public MultiSelectLookup multiselectlookup { get; set; }
        public Auto_Number auto_number { get; set; }
    }
    public class Currency
    {
    }
    public class Lookup
    {
    }
    public class ViewType
    {
        public bool view { get; set; }
        public bool edit { get; set; }
        public bool quick_create { get; set; }
        public bool create { get; set; }
    }
    public class Unique
    {
    }
    public class Formula
    {
    }
    public class MultiSelectLookup
    {
    }
    public class Auto_Number
    {
    }
    public class PickListValues
    {
        public string display_value { get; set; }
        public string actual_value { get; set; }
    }
