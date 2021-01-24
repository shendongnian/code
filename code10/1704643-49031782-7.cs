    public interface IMyLibrarySettings
    {
        Guid TheGuidINeed { get; }
    }
    public class MyLibrarySettings : IMyLibrarySettings
    {
        public MyLibrarySettings(Guid theGuidINeed)
        {
            TheGuidINeed = theGuidINeed;
        }
        public Guid TheGuidINeed { get; }
    }
    public class MyLibraryWindsorFacility : AbstractFacility
    {
        private readonly IMyLibrarySettings _settings;
        public MyLibraryWindsorFacility(IMyLibrarySettings settings)
        {
            _settings = settings;
        }
        protected override void Init()
        {
            // validate the settings, make sure they didn't leave stuff out
            // throw awesome clear exception messages.
            Kernel.Register(Component.For<IMyLibrarySettings>().Instance(_settings));
            // register the other dependencies in your library.
        }
    }
