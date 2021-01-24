    [XmlRoot("ManufacturerContainer")]
    public class ManufacturerContainer
    {
        [XmlArray("Manufacturers")]
        [XmlArrayItem("Manufacturer")]
        public List<Manufacturer> Manufacturers { get; set; }
    
        // Get all available Manufacturers' names
        public IEnumerable<string> GetAvailableManufacturers()
        {
            // use Linq to get a list of only the names
            return Manufacturers.Select(manufacturer => manufacturer.Name);
        }
    
        // Get a specific Manufacturer by name
        public Manufacturer GetManufacturerByName(string name)
        {
            // a little sanaty check
            if (GetAvailableManufacturers().Contains(name))
            {
                // again use Linq to return the Manufacturer by name
                // (provided that they are unique of course)
                return Manufacturers.Find(manufacturer => string.Equals(name, manufacturer.Name));
            }
    
            Debug.LogWarningFormat("No Manufacturer with name {0} found!", name);
            return null;
        }
    
        // and finally get a specific Model by manufacturer and model name
        public Model GetModelByName(string manufacturerId, string modelId)
        {
            // first get the according manufacturer
            var manufacturer = GetManufacturerByName(manufacturerId);
    
            if (manufacturer != null)
            {
                // get the model by name (see method below)
                return manufacturer.GetModelByName(modelId);
            }
    
            Debug.LogWarningFormat("Couldn't get Manufacturer with id {0}", manufacturerId);
            return null;
    
            // then the according model
        }
    }
    
    public class Manufacturer
    {
        [XmlAttribute("name")] public string Name { get; set; }
    
        [XmlElement("Model")] public List<Model> Models { get; set; }
    
        // Get all available Models' names
        public List<string> GetAvailableModels()
        {
            return Models.Select(model => model.Name).ToList();
        }
    
        // The same as for getting a Manufacturer by name
        public Model GetModelByName(string name)
        {
            // a little sanaty check
            if (GetAvailableModels().Contains(name))
            {
                // again use Linq to return the Model by name
                // (provided that they are unique of course)
                return Models.Find(model => string.Equals(name, model.Name));
            }
    
            Debug.LogWarningFormat("No Manufacturer with name {0} found!", name);
            return null;
        }
    }
    
    public class Model
    {
        [XmlAttribute("name")] public string Name { get; set; }
    }
