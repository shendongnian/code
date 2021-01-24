    public class Player
    {
        public string[] namelistImmunity = { "fire", "water", "giantEnemyCrab" };
        //paralell arrays
        public string[] namelistStatus = { "health", "stamina", "mana" };
        //get and set Variables from nested classes
        //('classname' is the name of the class,'propertyName' is the name of the variable)
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
    
            //display variables
            public void DisplayPlayerStatus()
            {
                foreach (var s in namelistStatus)
                    Console.WriteLine(s + ":" + this["Status", s]);
    
                foreach (var n in namelistImmunity) // fixed the wrong list used here
                    if (Convert.ToBoolean(this["Immunity", n]))
                        Console.WriteLine(n + " Immunity");
            }
    
            public static class Immunity { public static bool fire = false, water = false, giantEnemyCrab = true; };
    
            //categories of variables within static classes
            public static class Status { public static int health = 10, stamina = 10, mana = 10; };
        }
