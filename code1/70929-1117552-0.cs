    "But enums can't have spaces in C#!" you say. Well, I like to use the System.ComponentModel.DescriptionAttribute to add a more friendly description to the 
    enum values. The example enum can be rewritten like this:
    
    public enum States
    {
        California,
        [Description("New Mexico")]
        NewMexico,
        [Description("New York")]
        NewYork,
        [Description("South Carolina")]
        SouthCarolina,
        Tennessee,
        Washington
    }
    
    Notice that I do not put descriptions on items where the ToString() version of that item displays just fine.
