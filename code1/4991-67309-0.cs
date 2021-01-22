        public class IngredientBag
        {
          private Dictionary<string, string> _ingredients = 
    new Dictionary<string, string>();
          public void Add(string type, string name)
          {
            _ingredients[type] = name;
          }
          public string Get(string type)
          {
            return _ingredients.ContainsKey(type) ? _ingredients[type] : null;
          }
          public bool Has(string type, string name)
          {
            return name == null ? false : this.Get(type) == name;
          }
        }
        
        public Potion(string name) : this(name, new IngredientBag())    {    }
