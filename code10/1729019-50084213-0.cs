    public class UnitFactory
    {
        readonly DiContainer _container;
        readonly List<UnityEngine.Object> _prefabs;
        public UnitFactory(
            List<UnityEngine.Object> prefabs,
            DiContainer container)
        {
            _container = container;
            _prefabs = prefabs;
        }
        public BaseUnit Create<T>()
            where T : BaseUnit
        {
            var prefab = _prefabs.OfType<T>().Single();
            return _container.InstantiatePrefabForComponent<T>(prefab);
        }
    }
    public class TestInstaller : MonoInstaller<TestInstaller>
    {
        public FooUnit FooPrefab;
        public BarUnit BarPrefab;
        public override void InstallBindings()
        {
            Container.Bind<UnitFactory>().AsSingle();
            Container.Bind<UnityEngine.Object>().FromInstance(FooPrefab).WhenInjectedInto<UnitFactory>();
            Container.Bind<UnityEngine.Object>().FromInstance(BarPrefab).WhenInjectedInto<UnitFactory>();
        }
    }
