      class Program
        {
            enum Days
            {
                Monday,
                Tuesday,
                Wednesday
            }
    
            static void Main(string[] args)
            {
    
                Days[] allDays = { Days.Monday, Days.Tuesday, Days.Wednesday };
    
                // This prints true cause all enum days exist in allDays
                Debug.WriteLine(Enum.GetValues(typeof(Days)).OfType<Days>().Except(allDays).Count() == 0);
    
                Days[] someDays = { Days.Monday, Days.Wednesday };
    
                // This prints false cause not all days exist in someDays
                Debug.WriteLine(Enum.GetValues(typeof(Days)).OfType<Days>().Except(someDays).Count() == 0);
    
    
            }
        }
