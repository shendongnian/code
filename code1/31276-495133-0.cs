        public enum VolumeType
        {
            Litre = 0,
            Pint = 1,
            Gallon = 2
        }
        public static double ConvertUnits(int units, VolumeType from, VolumeType to)
        {
            double[][] factor = 
                {
                    new double[] {1, 2, 0.25},
                    new double[] {0.5, 1, 0.125},
                    new double[] {4, 8, 1}
                };
            return units * factor[(int)from][(int)to];
        }
        public static void ShowConversion(int oldUnits, VolumeType from, VolumeType to)
        {
            double newUnits = ConvertUnits(oldUnits, from, to);
            Console.WriteLine("{0} {1} = {2} {3}", oldUnits, from.ToString(), newUnits, to.ToString());
        }
        static void Main(string[] args)
        {
            ShowConversion(1, VolumeType.Litre, VolumeType.Litre);  // = 1
            ShowConversion(1, VolumeType.Litre, VolumeType.Pint);   // = 2
            ShowConversion(1, VolumeType.Litre, VolumeType.Gallon); // = 4
            ShowConversion(1, VolumeType.Pint, VolumeType.Pint);    // = 1
            ShowConversion(1, VolumeType.Pint, VolumeType.Litre);   // = 0.5
            ShowConversion(1, VolumeType.Pint, VolumeType.Gallon);  // = 0.125
            ShowConversion(1, VolumeType.Gallon, VolumeType.Gallon);// = 1
            ShowConversion(1, VolumeType.Gallon, VolumeType.Pint);  // = 8
            ShowConversion(1, VolumeType.Gallon, VolumeType.Litre); // = 4
            ShowConversion(10, VolumeType.Litre, VolumeType.Pint);  // = 20
            ShowConversion(20, VolumeType.Gallon, VolumeType.Pint); // = 160
        }
