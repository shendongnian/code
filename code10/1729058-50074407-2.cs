    void Main()
    {
    	var json =api();
    	
    	//dynamic
    	var dynamic_json = JsonConvert.DeserializeObject(json).Dump() as JObject;
    	
    	//strong type
    	var strong_Type_json = JsonConvert.DeserializeObject<Driver>(json).Dump() ;
    
    }
    
    string api(){
    	return @"
    {""status"":200,""data"":{""first_name"":""\u062e\u0633"",""last_name"":""\u0635\u062f\u0627"",""national_code"":""1"",""image_photo"":""1.jpg"",""cellphone"":""1234"",""city"":{""id"":1,""name"":""x"",""created_at"":""2017-02-27 17:54:44"",""updated_at"":""2017-02-27 17:54:44""},""email"":""something@gmail.com"",""even_odd"":1,""Register_Time"":""2018-01-25 10:39:17"",""is_blocked"":false,""receive_regular_offer"":""false"",""level"":1,""ride_count"":0,""service_type"":1,""bank"":""\u0645"",""iban"":""xy"",""card_number"":"""",""holder"":""\u062e\u0633"",""plate_number"":""123"",""vehicle_model"":""\u067e\u0698"",""vehicle_color"":""\u062a\u0627\u06a9\u0633"",""unique_id"":592875}}
    	";
    }
    
    
    public class City
    {
    	public int id { get; set; }
    	public string name { get; set; }
    	public string created_at { get; set; }
    	public string updated_at { get; set; }
    }
    
    public class Data
    {
    	public string first_name { get; set; }
    	public string last_name { get; set; }
    	public string national_code { get; set; }
    	public string image_photo { get; set; }
    	public string cellphone { get; set; }
    	public City city { get; set; }
    	public string email { get; set; }
    	public int even_odd { get; set; }
    	public string Register_Time { get; set; }
    	public bool is_blocked { get; set; }
    	public string receive_regular_offer { get; set; }
    	public int level { get; set; }
    	public int ride_count { get; set; }
    	public int service_type { get; set; }
    	public string bank { get; set; }
    	public string iban { get; set; }
    	public string card_number { get; set; }
    	public string holder { get; set; }
    	public string plate_number { get; set; }
    	public string vehicle_model { get; set; }
    	public string vehicle_color { get; set; }
    	public int unique_id { get; set; }
    }
    
    public class Driver
    {
    	public int status { get; set; }
    	public Data data { get; set; }
    }
