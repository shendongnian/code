    public class PaymentSection : ConfigurationSection
    {
       // Simple One
       [ConfigurationProperty("name")]]
       public String name
       {
          get { return this["name"]; }
          set { this["name"] = value; }
       }
      
    }
