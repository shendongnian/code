       private static int TestDoubleToEngineeringOne(double value, string expected)
        {
            var fakePrecision = "4";
            int NError = 0;
            var actual = DoubleToEngineering(value, fakePrecision);
            if (actual != expected)
            {
                System.Diagnostics.Debug.WriteLine($"ERROR: DoubleToEngineering({value}) expected {expected} actual {actual}");
                NError++;
            }
            return NError;
        }
        public static int TestDoubleToEngineering()
        {
            int NError = 0;
            NError += TestDoubleToEngineeringOne(0, "0.0000");
            NError += TestDoubleToEngineeringOne(1, "1.0000");
            NError += TestDoubleToEngineeringOne(2, "2.0000");
            NError += TestDoubleToEngineeringOne(3, "3.0000");
            NError += TestDoubleToEngineeringOne(10, "10.0000");
            NError += TestDoubleToEngineeringOne(999, "999.0000");
            NError += TestDoubleToEngineeringOne(1000, "1.0000e3");
            NError += TestDoubleToEngineeringOne(1.234E21, "1.2340e21");
            NError += TestDoubleToEngineeringOne(-1, "-1.0000");
            NError += TestDoubleToEngineeringOne(-999, "-999.0000");
            NError += TestDoubleToEngineeringOne(-1000, "-1.0000e3");
            NError += TestDoubleToEngineeringOne(0.1, "100.0000e-3");
            NError += TestDoubleToEngineeringOne(0.02, "20.0000e-3");
            NError += TestDoubleToEngineeringOne(0.003, "3.0000e-3");
            NError += TestDoubleToEngineeringOne(0.0004, "400.0000e-6");
            NError += TestDoubleToEngineeringOne(0.00005, "50.0000e-6");
            NError += TestDoubleToEngineeringOne(double.NaN, "NaN");
            NError += TestDoubleToEngineeringOne(double.PositiveInfinity, "∞");
            NError += TestDoubleToEngineeringOne(double.NegativeInfinity, "-∞");
            NError += TestDoubleToEngineeringOne(double.Epsilon, "4.9407e-324");
            NError += TestDoubleToEngineeringOne(double.MaxValue, "179.7693e306");
            NError += TestDoubleToEngineeringOne(double.MinValue, "-179.7693e306");
            return NError;
        }
