     public class CityModel
        {
            public string city { get; set; }
            public string state { get; set; }
            public string city_type { get; set; }
            public bool active { get; set; }
            public string route { get; set; }
            public string date_of_discontinuance { get; set; }
            public string state_code { get; set; }
            public int pincode { get; set; }
            public string city_code { get; set; }
            public string dccode { get; set; }
        }
    string JsonResult = @"[{'city': 'AMBALA', state: 'Haryana', 'city_type': '', 'active': true, 'route': 'HR / I1H / ABA', 'date_of_discontinuance': '', 'state_code': 'HR', 'pincode': 134003, 'city_code': 'ABA', 'dccode': 'ABA'},{ 'city': 'AMBALA', 'state': 'Haryana', 'city_type': '', 'active': true, 'route': 'HR/I1H/ABA', 'date_of_discontinuance': '', 'state_code': 'HR', 'pincode': 134002, 'city_code': 'ABA', 'dccode': 'ABA'}]";
    var result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CityModel>>(JsonResult);  
    
