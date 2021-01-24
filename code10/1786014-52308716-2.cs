    <Window.Resources>
        <DataTemplate DataType="{x:Type local:Unit}">
            <StackPanel>
                <TextBlock Text="{Binding Name}"/>
                <TextBlock Text="{Binding UnitData}"/>
            </StackPanel>
        </DataTemplate>
        <DataTemplate DataType="{x:Type local:Component}">
            <StackPanel>
                <TextBlock Text="{Binding Name}"/>
                <TextBlock Text="{Binding ComponentData}"/>
            </StackPanel>
        </DataTemplate>
    </Window.Resources>
    <Grid>
        <Grid.ColumnDefinitions>
            <ColumnDefinition/>
            <ColumnDefinition/>
        </Grid.ColumnDefinitions>
        <ListBox ItemsSource="{Binding Objects}"
                 DisplayMemberPath="Name"
                 SelectedItem="{Binding SelectedObject}"/>
        <ContentControl Grid.Column="1" Content="{Binding SelectedObject}"/>
    </Grid>
