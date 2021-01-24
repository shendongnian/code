    public class Plains : Turf
    {
        public Plains()
        {
            allowed_contents = new Dictionary<Type, int>()
            {
                {typeof(Forest), 100},
                {typeof(Tall_Grass),  25},
                {typeof(Mountain), 10}
            };
        }
    }
