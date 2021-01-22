    class UC : UserControl
    {
    protected string DisplayName
    {
        get
        {
            return Instance.DisplayName;
        }
    }
    /*********** MAGIC Property ****************/
    private FoodState _instance = null;
    private FoodState Instance
    {
        get
        {
           if (_instance == null)
           {
               if (FoodType == "Veg")
               {
                     _instance = new VegFood();
               }
               else
               {
                     _instance = new NonvegFood();
               }
           }
           return _instance;
        }
    }
    abstract class FoodState
    {
        abstract public string DisplayName {get;}
    }
    class VegFood : FoodState
    {
        public string DisplayName
        {
          get
          {
            return "Rice";
          }
        }       
    }
    class NonvegFood : FoodState
    {
        public string DisplayName
        {
          get
          {
            return "Chicken";
          }
        }       
    }
 
    }
    
