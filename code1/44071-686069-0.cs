        // The string returned is the path
        public string TimeOfDay()
        {
            // How you define 
            if(System.DateTime.Now.Hour > 8 && System.DateTime.Now.Hour < 10)
                return @"D:\Morning\";
            else if(System.DateTime.Now.Hour > 10 && System.DateTime.Now.Hour < 18)
                return @"D:\Afternoon\";
            else
                return @"D:\Night\";
        }
