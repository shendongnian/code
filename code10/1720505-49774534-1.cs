    public class ScriptableLevelInstaller : ScriptableObjectInstaller<ScriptableLevelInstaller>
    {
        public Archer.AracherSettings Aracher;
        public Knight.KnightSettings Knight;
        public override void InstallBindings()
        {
            Container.BindInstance(Aracher).WhenInjectedInto<Archer>();
            Container.BindInstance(Knight).WhenInjectedInto<Knight>();
        }
    }
