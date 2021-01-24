    public class ModularRing : Scaffolding.IRing<int>
    {
        public IGroup<int> AdditiveStructure { get; } = new ModularGroup();
        public IMonoid<int> MultiplicativeStructure { get; } = new ModularMonoid();
    }
