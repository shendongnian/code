    public class Person
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
    }
    var people = new[]
    {
        new Person{FirstName = "Peter", Surname = "Pan"}, 
        new Person{FirstName = "Simon", Surname = "Cowell"}
    };
    var listbox = new ListBox
    {
      DisplayMember = "FirstName",
      ValueMember = "FirstName",
      DataSource = people
    };
    var person = listbox.SelectedItem as Person;
