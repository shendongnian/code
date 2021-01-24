     string json = "{\n  \"Vehicles\": [\n    {\n      \"Make\": \"Toyota\",\n      \"Model\": \"Camry\",\n      \"Wheels\": 4,\n      \"CarImage\": \"Assets/Resources/Sprites/Slide1.png\"\n    },\n    {\n      \"Make\": \"Yamaha\",\n      \"Model\": \"Di ko balo\",\n      \"Wheels\": 2,\n      \"CarImage\": \"Assets/Resources/Sprites/Slide1.png\"\n    },\n    {\n      \"Make\": \"Ford\",\n      \"Model\": \"Ranger\",\n      \"Wheels\": 4,\n      \"CarImage\": \"Assets/Resources/Sprites/Slide1.png\"\n    }\n  ]\n}";
 
              VehicleList = JsonUtility.FromJson<VehiclesLists>(json);
    
                foreach (var vehicle in root.Vehicles)
                {
                    vehicle.CarImageSprite = Resources.Load(vehicle.CarImageStr, typeof(Sprite)) as Sprite;
                    print(vehicle.CarImageStr);
                }
        public class Vehicle
        {
            public string Make { get; set; }
            public string Model { get; set; }
            public int Wheels { get; set; }
            public string CarImageStr { get; set; }
            public Sprite CarImageSprite { get; set; }
        }
        public class RootObject
        {
            public List<Vehicle> Vehicles { get; set; }
        }
