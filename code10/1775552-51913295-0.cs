    class BiomeElement
    {
        public BiomeElement(int biome, int element)
        {
            Biome = biome;
            Element = element;
        }
        
        public int Biome { get; }
        public int Element { get; }
    
        public bool IsForestGrass { get { return Biome == 1 && Element == 1; } }
        public bool IsForestWater { get { return Biome == 1 && Element == 2; } }
    }
