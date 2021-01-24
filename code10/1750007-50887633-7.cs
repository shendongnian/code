    public class Player
    {
        public string[] namelistImmunity = { "fire", "water", "giantEnemyCrab" };
        public string[] namelistStatus = { "health", "stamina", "mana" };
        public object this[string className, string propertyName]
        {
            //indirectly calls variables within static classes entirely via string
            get
            {
                var innerClass = GetType().GetNestedType(className);
                var myFieldInfo = innerClass?.GetField(propertyName);
                return myFieldInfo.GetValue(null);
            }
            set
            {
                var innerClass = GetType().GetNestedType(className);
                var myFieldInfo = innerClass?.GetField(propertyName);
                myFieldInfo?.SetValue(null, value);
            }
        }
        public void DisplayPlayerStatus()
        {
            // why for and indexing - foreach is far easier
            foreach (var s in namelistStatus)
                Console.WriteLine(s + ":" + this["Status", s]);
    
            // you used the wrong list of names here 
            foreach (var n in namelistImmunity) 
                if (Convert.ToBoolean(this["Immunity", n]))
                    Console.WriteLine(n + " Immunity");
        }
    
        public static class Immunity 
        {
            // these are fields 
            public static bool fire = false, 
                               water = false, 
                               giantEnemyCrab = true; 
        };
    
        public static class Status 
        {
            // fields as well 
            public static int health = 10, 
                          stamina = 10, 
                          mana = 10; 
        };
    }
    
