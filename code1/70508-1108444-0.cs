    //Controller:
    public class PersonController
    {
        public PersonAction Detail(int personId)
        {
            Person returnValue;
            
            //get person from DB and populate returnValue
            return new PersonAction( returnValue );
        }
    }
    //Model:
    public class Person
    {
        public string FirstName {get; set;}
        public string LastName {get; set;}
    }
    //View:
    public partial class PersonDetailView : MVCForm<Person>
    {
        public Form1( Person model ):base(model) { ... }
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = model.FirstName + " " + model.LastName;
        }
    }
