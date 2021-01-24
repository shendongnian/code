    public abstract class EnumExtension<T> where T : struct
    {
       public bool updateEnum(string name){
         //code to update the enum extension
       }
    }
    
    public class EnumExtensionForVehicle : EnumExtension<Vehicle>
    {
       public bool updateEnum(string name){
         //code to update the enum extension
       }
    }
    
    public class EnumExtensionForParkingArea : EnumExtension<ParkingArea>
    {
       public bool updateEnum(string name){
         //code to update the enum extension
       }
    }
    
    public class MyController : ApiController
    {   
       public void UpdateAnyEnum<T>(string newName, int value, string typeName) {
            EnumExtension<T> factory;
    
            switch (typeName)
            {
                case "Vehicle":
                    factory = new EnumExtensionForVehicle();
                    break;
                case "ParkingArea":
                    factory = new EnumExtensionForParkingArea();
                    break;
            }
    
            factory.updateEnum(newName);
       }
    }
