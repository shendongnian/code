    public class Car {
    
        private CarDto _dto = null;
        public Car(CarDto dto = null) {
            //If we pass in a dto, use it, otherwise create a new one
            _dto = dto ?? new CarDto();
        }
    
        [JsonProperty("make")]
        public string Make {
            get {
                if (_dto.Make == null) {
                    UpdateProperties();
                }
                return _dto.Make;
            }
        }
    
        [JsonProperty("model")]
        public string Model {
            get {
                if (_dto.Model == null) {
                    UpdateProperties();
                }
                return _dto.Model;
            }
        }
    
        [JsonProperty("self")]
        public Uri Self { get; set; }
    
        public void UpdateProperties() { 
            //The API would return a CarDto.
            CarDto newDto = APICall(); //Mock code
            _dto = newDto;
        }
    }
    
    public class CarDto {
        public string Make { get;set; }
        public string Model { get;set; }
    }
