    public enum VehiclePart{
      Hull,
      Wheels,
      Breaks,
      Hydraulics,
      Interior,
      Handrail,
    }
    
    //vehicle types
    public abstract class Vehicle {
        public virtual List<VehiclePart> GetPartsToRepair(){
    		return new List<VehiclePart>(){ VehiclePart.Hull, VehiclePart.Wheels, VehiclePart.Breaks };
    	}
    }
    
    public class Car : Vehicle { }
    
    public class Truck : Vehicle 
    {
    	public override List<VehiclePart> GetPartsToRepair(){
    		var result = base.GetPartsToRepair();
    		result.Add(VehiclePart.Hydraulics);
            return result;
    	}
    }
    
    public class Bus : Vehicle 
    {
    	public override List<VehiclePart> GetPartsToRepair(){
    		var result = base.GetPartsToRepair();
    		result.Add(VehiclePart.Interior);
            return result;
    	}
    }
