    <UserControl ...>
        <Grid>
            <Grid.ColumnDefinitions>
                <ColumnDefinition/>
                <ColumnDefinition/>
            </Grid.ColumnDefinitions>
            <ListBox ItemsSource="{Binding Trains}"
                     SelectedItem="{Binding SelectedTrain}"
                     DisplayMemberPath="Name"/>
            <local:TrainDetailsControl Grid.Column="1" DataContext="{Binding SelectedTrain}"/>
        </Grid>
    </UserControl>
