     public enum LegalShipTypes : byte
        {
            Frigate = 1,
            Cruiser = 2,
            Destroyer = 3,
            Submarine = 4,
            AircraftCarrier = 5
        }
        class Program
        {
            static void Main()
            {
                byte sum = 0;
                foreach (byte item in Enum.GetValues(typeof(LegalShipTypes)))
                {
                    sum += (byte)(object)item;
                }
    
                Console.WriteLine(sum);
            }
        }
