    public class Car
    {
        public string Brand { get; set; } 
        public string Model { get; set; }
        public string Color { get; set; }
    }
    var cars = new List<Car>();
    cars.Add(new Car { Name = textBox1.Text, Color = textBox2.Text, Model = textBox3.Text });
