        public partial class Test2 : DefaultPage
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                var car = new Car();
                car.NumberPlate = "new number plate";
                Response.Write(car.NumberPlate);
            }
        }
    
    
    public class Car
    {
    
        public Car()
        {
            NumberPlate="old number plate";
        }
    
        public string NumberPlate { get; set; }
    
    }
