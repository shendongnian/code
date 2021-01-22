     public static void testCOnvertAll()
            {
                List<double> target = new List<double>();
                target.Add(2.3);
                target.Add(2.4);
                target.Add(3.2);
    
                List<int> result = target.ConvertAll<int>(new Converter<double, int>(DoubleToInt));
                
            }
    
            public static int DoubleToInt(double toConvert)
            {
                return Convert.ToInt32(toConvert);
            }
