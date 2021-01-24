    public sealed partial class MainPage : Page
    { 
        public bool is_arrived = false;
        public MainPage()
        {
            this.InitializeComponent();
            bool is_arrived=true;
            CallingWebServices asyn_task = new CallingWebServices(this);
        }
        public class CallingWebServices
        {
             private MainPage _Instance;
             public CallingWebServices(MainPage instance)
             {
                _Instance=instance;
             }
            //Access variable "instance.is_arrived" here.
         }
    }
