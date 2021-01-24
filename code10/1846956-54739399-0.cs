    public class NewForm
    {
        public NewForm()
        {
            // instantiate list here
            Fields = new List<Field>();
        }
        [Key]
        public int Id { get; set; }
        public string HeadForm { get; set; }
        public List<Field> Fields { get; set; }   
    }
