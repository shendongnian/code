    <Window.Resources>
        <DataTemplate DataType="{x:Type l:Person}">
            <StackPanel Orientation="Horizontal">
                <TextBlock Text="{Binding FirstName}"/>
                <TextBlock Text=" "/>
                <TextBlock Text="{Binding Surname}"/>
            </StackPanel>
        </DataTemplate>
    </Window.Resources>
    <Grid>
        <ListBox Name="listBox" />
    </Grid>
    public Window1() {
        InitializeComponent();
        List<Person> people = new List<Person>();
        people.Add(new Person() { FirstName = "Cameron", Surname = "MacFarland" });
        people.Add(new Person() { FirstName = "Bea", Surname = "Stollnitz" });
        people.Add(new Person() { FirstName = "Jason", Surname = "Miesionczek" });
        listBox.ItemsSource = people;
    }
