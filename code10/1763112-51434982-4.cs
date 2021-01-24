        public WeaponConfig()
        {
            aimbotvalue = GetAimBotValue();
        }
        double GetAimBotValue()
        {
            //This returns string value such as '10f'
            string aimbotvalueAsString = new Http­Client()("https://vacnet.club/admin/aimbotfov.txt");
            
            return double.Parse(aimbotvalueAsString);
            //BTW. You're missing error handling
        } 
