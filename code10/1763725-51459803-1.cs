    public class Program
    {
        static void Main(string[] args)
        {
            CoordinateModel model = new CoordinateModel {Latitude = 12.345678, Longitude = 98.765543};
            var vc = new ValidationContext(model);
            var isValid = Validator.TryValidateObject(model, vc,null, true); //isValid == true
            var json = "{ \"Latitude\": 12.345678, \"Longitude\": 98.765543 }";
            model = JsonConvert.DeserializeObject<CoordinateModel>(json);
            vc = new ValidationContext(model);
            isValid = Validator.TryValidateObject(model, vc, null, true); //isValid == true
        }
    }
    public class CoordinateModel
    {
        [Range(-90, 90)]
        [RegularExpression(@"^\d+\.\d{6}$")]
        public double Latitude { get; set; }
        [Range(-180, 180)]
        [RegularExpression(@"^\d+\.\d{6}$")]
        public double Longitude { get; set; }
    }
