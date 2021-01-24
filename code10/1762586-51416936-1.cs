    public sealed partial class MainPage : Page
    { 
        public bool is_arrived = false;
        public MainPage()
        {
            this.InitializeComponent();
            bool is_arrived=true;
            CallingWebServices asyn_task = new CallingWebServices(is_arrived);
        }
        public class CallingWebServices
        {
             private bool _isArrived;
             public CallingWebServices(bool isArrived)
             {
                _isArrived=isArrived;
             }
            //want to access variable "is_arrived" here.
        }
    }
