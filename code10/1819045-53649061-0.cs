    public class Car : IVehicle
    {
        List<Part> GetParts(int id)
        {
            //return list of car parts
        }
        IEnumerable<Part> IVehicle.GetParts(int id) => this.GetParts(id);
    }
