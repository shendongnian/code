    <ListBox ItemsSource="{Binding ElementList}"
             SelectedItem="{Binding SelectedElement}">
    	<ListBox.Resources>
    		<BooleanToVisibilityConverter x:Key="BooleanToVisibilityConverter"/>
    	</ListBox.Resources>
        <ListBox.ItemTemplate>
            <DataTemplate>
                <Grid>
                    <TextBlock Text="{Binding Name}" />
                </Grid>
            </DataTemplate>
        </ListBox.ItemTemplate>
        <ListBox.ContextMenu>
            <ContextMenu>
                <MenuItem Name="Add" Click="Add_Click" Header="Add element" />
                <MenuItem Name="Delete" Click="Delete_Click" 
                          HeaderStringFormat="Delete element {0}" 
                          Header="{Binding SelectedElement.Name}" 
                          Visibility="{Binding PlacementTarget.HasItems, RelativeSource={RelativeSource AncestorType=ContextMenu}, Converter={StaticResource BooleanToVisibilityConverter}}" />
            </ContextMenu>
        </ListBox.ContextMenu>
    </ListBox>
