    public interface IManufacturer 
    {
         IEnumerable<Model> Models {get;}
         void AddModel(Model model);
    }
