    <Grid>
        <Grid.ColumnDefinitions>
            <ColumnDefinition />
            <ColumnDefinition />
        </Grid.ColumnDefinitions>
        <ComboBox ItemsSource="{Binding events}" SelectedItem="{Binding currentEvent}">
            <ComboBox.ItemTemplate>
                <DataTemplate>
                    <TextBlock Text="{Binding name}"/>
                </DataTemplate>
            </ComboBox.ItemTemplate>
        </ComboBox>
        <ListView Grid.Column="1" ItemsSource="{Binding participants}">
            <ListView.View>
                <GridView>
                    <GridViewColumn Header="First Name" DisplayMemberBinding="{Binding firstName}"/>
                    <GridViewColumn Header="Last Name" DisplayMemberBinding="{Binding lastName}"/>
                </GridView>
            </ListView.View>
        </ListView>
    </Grid>
