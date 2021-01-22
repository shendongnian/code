    public class Person
    {
        string Forename { get; set; }
        string Surname { get; set; }
        string FullName 
        {
            get { return String.Format("{0} {1}", Forename, Surname); }
        }
    }
