        public static string RatingCalculator(int input)
        {
            if (input > 120)
            {
                return GetStart(5);
            }
            if (input > 70)
            {
                return GetStars(4);
            }
            if (input > 40)
            {
                return GetStars(3);
            }
            if (input > 20)
            {
                return GetStars(2);
            }
            if (input > 10)
            {
                return GetStars(1);
            }
            else
            {
                return string.Empty;
            }
        }
        //populate dictionary with values in your class ctor
        private static IDictionary<int, string> images=new Dictionary<int,string>();
        private static string GetStars(int stars)
        {
            if(images.ContainsKey(stars))
                return images[stars];
            return string.Empty;
        }
