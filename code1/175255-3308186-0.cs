    public class CustomActions 
    { 
        [CustomAction] 
        public static ActionResult action1(Session session) 
        { 
            string xyzProperty = "XYZ";
    
            session[xyzProperty] = "ABC";
        } 
    } 
