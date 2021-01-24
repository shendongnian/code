    public interface IVehicle
    {
        string Brand { get; set; }
        string Model { get; set; }
        int HorsePower { get; set; }
        void setInformation;
        InformObject getInformation;
    
    }
    
    public interface IMotorcycle : IVehicle
    {
        DateTime DateCreated { get; set; }
    }
    
    public abstract class Vehicle : IVehicle
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }
        public void setInformation(string brand, string model, int hPower){
           Brand = brand;
           Model = model;
           HorsePower = hPower;
        }
        public InfoObject getInformation(){
           return new InfoObject(Brand, Model, HorsePower);
        }
    
    }
    
    public class Car : Vehicle, IVehicle
    { }
    
    public class Motorcycle : Vehicle, IVehicle, IMotorcycle
    {
        public DateTime DateCreated { get; set; }
    }
    
    public class InfoObject 
    {
        public InfoObject(string brand, string model, int hPower){
           Brand = brand;
           Model = model;
           HorsePower = hPower;
        }
    
        public InfoObject(string brand, string model, int hPower, DateTime timeCreated){
           Brand = brand;
           Model = model;
           HorsePower = hPower;
           DateCreated = timeCreated;
        }
    
        public string Brand { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }
        DateTime DateCreated { get; set; }
    }
