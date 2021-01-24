    public class Rootobject
    {
        public string branch_key { get; set; }
        public string channel { get; set; }
        public string feature { get; set; }
        public string campaign { get; set; }
        public string stage { get; set; }
        public string[] tags { get; set; }
        public Data data { get; set; }
    }
    public class Data
    {
        public string canonical_identifier { get; set; }
        public string og_title { get; set; }
        public string og_description { get; set; }
        public string og_image_url { get; set; }
        public string desktop_url { get; set; }
        public bool custom_boolean { get; set; }
        public int custom_integer { get; set; }
        public string custom_string { get; set; }
        public int[] custom_array { get; set; }
        public Custom_Object custom_object { get; set; }
    }
    public class Custom_Object
    {
        public string random { get; set; }
    }
