    public class InnerObject
    {
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
       public InnerObject WithBirthday(DateTime date)
               {    return new InnerObject
                     {
                          Name = this.Name,
                          // add other properties here
                          Birthday = date
                    };
                }
