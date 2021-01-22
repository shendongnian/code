    public class Product : IEntity {
      public Product() {}
    }
    
    public class Wrong {
      public Wrong() {}
    }
    
    public class WrongAgain : IEntity {
       private Wrong() {}
    }
    
    
    // compiles
    public ProductManager : BaseEntityManager<Product> {}
    
    
    // Error - not implementing IEntity
    public WrongManager : BaseEntityManager<Wrong> {}
    
    
    / Error - no public parameterless constructor
    public WrongAgainManager : BaseEntityManager<WrongAgain> {}
