    public class Property 
    { 
    
        public String Title {get; set};
        public String Area {get; set};
        public int Sleeps {get; set};
    
        public static void main(String[] args)
        {
    
            Property newProperty = new Property {Title="Test Property", Area="Test Area", Sleeps=7};
    
        }
    }
