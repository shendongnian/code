     public interface IMealTime
        {
            DateTime Time { get; set; }
        }
    
        public class Lunch : IMealTime
        {
            #region IMealTime Members
    
            public DateTime Time { get; set; }
    
            #endregion
        }
    
        public class Dinner : IMealTime
        {
            #region IMealTime Members
            public DateTime Time { get; set; }
    
            #endregion
        }
    
        public class GenericMeal
        {
            public DateTime GetMealTime<T>(T meal) where T: IMealTime
            {
                return meal.Time;
            }
        }
