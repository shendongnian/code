    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto" />
            <RowDefinition Height="*" />
        </Grid.RowDefinitions>
        <ComboBox 
              ItemsSource="{Binding AvailableLanguages}"
              SelectionChanged="OnLanguageSelectionChanged"
              DisplayMemberPath="NativeName"/>
        <TextBox x:Name="textBox" Grid.Row="1"
             AcceptsReturn="True"
             AcceptsTab="True"
             SpellCheck.IsEnabled="True"
             Text="Hello world"/>
    </Grid>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AvailableLanguages = new ObservableCollection<CultureInfo>();
            foreach (CultureInfo culterInfo in InputLanguageManager.Current.AvailableInputLanguages)
            {
                AvailableLanguages.Add(culterInfo);
            }
            DataContext = this;
        }
        public ObservableCollection<CultureInfo> AvailableLanguages
        {
            get { return (ObservableCollection<CultureInfo>)GetValue(AvailableLanguagesProperty); }
            set { SetValue(AvailableLanguagesProperty, value); }
        }
        public static readonly DependencyProperty AvailableLanguagesProperty = DependencyProperty.Register("AvailableLanguages", typeof(ObservableCollection<CultureInfo>), typeof(MainWindow));
        private void OnLanguageSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CultureInfo xmlLanguage = e.AddedItems[0] as CultureInfo;
            textBox.Language = XmlLanguage.GetLanguage(xmlLanguage.Name);
        }
    }
