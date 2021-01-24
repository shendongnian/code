    public class VehicleInfo
    {
    	public bool allowdrive {get; set; }
    	public string vehicle {get; set; }
    }
    
    public partial class Vehicle_Bar : UserControl
    {  	
    	public VehicleInfo vehicleInfo;
    
        public Vehicle_Bar(string vehicle)
        {
    		vehicleInfo = new VehicleInfo(){
    			vehicle = vehicle,
    			allowdrive = false
    		};
    		
            InitializeComponent();
        }
    
        private void Vehicle_Bar_Load(object sender, EventArgs e)
        {
            lblType.Text = vehicleInfo.vehicle;
        }
    	
    	//Handle checkbox click event to set the value of "allowdrive"
    }
