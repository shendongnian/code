    <Page x:Class="WpfApp1.Battle"
          xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
          xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
          Title="Battle">
        <Grid>
            <Grid.ColumnDefinitions>
                <ColumnDefinition Width="*"></ColumnDefinition>
                <ColumnDefinition Width="Auto"></ColumnDefinition>
                <ColumnDefinition Width="*"></ColumnDefinition>
            </Grid.ColumnDefinitions>
            <Label HorizontalContentAlignment="Center" VerticalContentAlignment="Center" Content="{Binding UserPokemon.Name}" FontSize="40" FontWeight="ExtraBold"></Label>
            <Label VerticalContentAlignment="Center" FontSize="20" FontWeight="ExtraBold" Grid.Column="1">VS</Label>
            <Label HorizontalContentAlignment="Center" VerticalContentAlignment="Center" Content="{Binding OpponentPokemon.Name}" FontSize="40" FontWeight="ExtraBold" Grid.Column="2"></Label>
        </Grid>
    </Page>
    public partial class Battle : Page
    {
        public Pokemon UserPokemon { get; set; }
        public Pokemon OpponentPokemon { get; set; }
        public Battle()
        {
            InitializeComponent();
            DataContext = this;
        }
        public Battle(Pokemon userPkmn, Pokemon opponentPkmn) : this()
        {
            UserPokemon = userPkmn;
            OpponentPokemon = opponentPkmn;
        }
    }
