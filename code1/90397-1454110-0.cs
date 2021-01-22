      public partial class Form1 : Form
        {
            Person person;
            public Form1()
            {
                InitializeComponent();
    
                person = new Person();
                this.titleTextBox.DataBindings.Add("Text", person, "DisplayName");
                this.firstNameTextBox.DataBindings.Add("Text", person.MainDetail, "FirstName");
            }
        }
    
        public class Person
        {
            public Int32 ID { get; set; }
            public Boolean IsMarried { get; set; }
            public String DisplayName { get; set; }
            public Detail MainDetail { get; set; }
            public Detail PartnerDetail  { get; set; }
    
            public Person()
            {
                MainDetail = new Detail();
                PartnerDetail = new Detail();
            }
        }
    
        public class Detail
        {
            public String FirstName { get; set; }
            public String LastName { get; set; }
            public DateTime DateOfBirth { get; set; }
            public String Address { get; set; }
        }
