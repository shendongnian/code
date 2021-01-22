    public static string Greet(string name, IGreetable whatever)
    {
        string greeting = "welcome  ";
        whatever.Greeting = string.Concat(greeting, name);
        return name;
    }
    public interface IGreetable {
        string Greeting {get;set;}
    }
    public class MyForm : Form, IGreetable {
        // snip some designer code
        public string Greeting {
            get { return helloLabel.Text;}
            set { helloLabel.Text = value;}
        }
        public void SayHello() {
            Greet("Fred", this);
        }
    }
