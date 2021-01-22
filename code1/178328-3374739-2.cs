    <ListBox x:Name="lstSubsystems" ItemsSource="{Binding SubSystems}">
        <ListBox.ItemTemplate>
            <DataTemplate>
                <CheckBox IsChecked="{Binding IsSelected}">
                    <ContentPresenter Content="{Binding Name}"  />
                </CheckBox>
            </DataTemplate>
        </ListBox.ItemTemplate>
    </ListBox>
