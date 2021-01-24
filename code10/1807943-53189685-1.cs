    static void PrintHighestHallmark(List<JeweleryContainer> shops)
    {
        foreach(JeweleryContainer s in shops)
        {
            int count = s.earring.Count + s.necklace.Count + s.ring.Count;
            Console.WriteLine("Parduotuveje " + s.Name + " yra " + count + " auksciausios prabos gaminiai(iu).");
        }
    }
