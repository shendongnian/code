    public interface ILoaderViewModel
    {
        IReadOnlyCollection<ClientMatter> Load();
    }
    
    public class ExcelMatterListLoaderViewModel : ILoaderViewModel
    {
        private readonly ExcelMatterListLoader loader;
    
        public string InputFilePath { get; set; }
    
        public uint StartRowNum { get; set; }
        public uint StartColNum { get; set; }
        public ExcelMatterListLoaderViewModel(ExcelMatterListLoader loader)
        {
            this.loader = loader;
        }
    
        IReadOnlyCollection<ClientMatter> Load()
        {
            // Stuff
            loader.Load(fromFile);
        }
    }
    
    public sealed class MainViewModel
    {
        private ExcelMatterListLoaderViewModel matterListLoaderViewModel;
        public ObservableCollection<ClientMatter> ClientMatters
            = new ObservableCollection<ClientMatter>();
    
        public MainViewModel(ExcelMatterListLoaderViewModel matterListLoaderViewModel)
        {
            this.matterListLoaderViewModel = matterListLoaderViewModel;
        }
    
        public void LoadCommand()
        {
            var clientMatters = matterListLoaderViewModel.Load();
    
            foreach (var matter in clientMatters)
            {
                ClientMatters.Add(matter)
            }
        }
    }
