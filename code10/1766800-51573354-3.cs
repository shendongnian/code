    public class ModularRing : Scaffolding.IRing<int, ModularGroup, ModularMonoid>
    {
        public ModularGroup AdditiveStructure { get; set; }
        public ModularMonoid MultiplicativeStructure { get; set; }        
    }
