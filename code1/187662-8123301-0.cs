    class Program
    {
        static void Main(string[] args)
        {
            PropertyNotification notification = new PropertyNotification();   //Create an object of PropertyNotification class.
            //Create EmployeeValueChange handler.
            PropertyNotification.EmployeeValueChange += new PropertyNotification.EmployeeNameHandler(PropertyNotification_EmployeeValueChange);
 
            //Display a message.
            Console.Write("Enter Value  :  ");
            //Read a value and initilize it in property.
            notification.EmployeeName = Console.ReadLine();
        }
 
        //Handler for property notification is created.
        static void PropertyNotification_EmployeeValueChange(object sender, EventArgs e)
        {
            Console.WriteLine("Employee name is changed."+sender);
        }
    }
 
    public class PropertyNotification
    {
        //Create a private variable which store value.
        private static string _employeeName;
        //Create a delegate of named EmployeeNamed=Handler
        public delegate void EmployeeNameHandler(object sender, EventArgs e);
 
        //Create a event variable of EmployeeNameHandler
        public static event EmployeeNameHandler EmployeeValueChange;
 
        //Create a static method named OnEmployeeNameChanged
        public static void OnEmployeeNameChanged(EventArgs e)
        {
            if (EmployeeValueChange != null)
                EmployeeValueChange(_employeeName, e);
        }
 
        //Create a property EmployeeName
        public string EmployeeName
        {
            get
            {
                return _employeeName;
            }
            set
            {
                //Check if value of property is not same.
                if (_employeeName != value)
                {
                    OnEmployeeNameChanged(new EventArgs());
                    _employeeName = value;
                }
            }
        }
    }
