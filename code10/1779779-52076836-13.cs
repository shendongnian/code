    public class Acs_Transaction_New_class
    {
    	public DateTime Date {get; set;}
    	public string acs_operations {get; set;}
    	public int acs_rfid_no {get; set;}
    	public int acs_vehicle_id {get; set;}
    	public DateTime acs_datetime {get; set;}
    }
    
    public class PassLinking_Class
    {
    	public int RfidNumber { get; set; }
    	public int VehicleID { get; set; }
    }
