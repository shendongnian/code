    // The simple object
    public class GameData
    {
        public string Team { get; set; }
    }
    public partial class Window1 : Window
    {
        public ObservableCollection<GameData> GameCollection { get; set; }
        public Window1()
        {
            this.DataContext = this;
            GameCollection = new ObservableCollection<GameData>();
            GameCollection.Add(new GameData(){Team = "Tigers"});
            GameCollection.Add(new GameData(){Team = "Royals" });
            GameCollection.Add(new GameData(){Team = "Indians" });
            InitializeComponent();
        }
    }
    <Grid>
        <ListBox ItemsSource="{Binding GameCollection}" DisplayMemberPath="Team"/>
    </Grid>
