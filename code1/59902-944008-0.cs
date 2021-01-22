    <Menu>
        <MenuItem Header="{Binding Name}" ItemsSource="{Binding MenuOptions}">
            <MenuItem.ItemTemplate>
                <HierarchicalDataTemplate ItemsSource="{Binding Categories}">
                    <MenuItem Header="{Binding Name}"/>
                    <HierarchicalDataTemplate.ItemTemplate>
                        <DataTemplate>
                            <MenuItem Header="{Binding Name}"/>
                        </DataTemplate>
                    </HierarchicalDataTemplate.ItemTemplate>
                </HierarchicalDataTemplate>
            </MenuItem.ItemTemplate>
        </MenuItem>
    </Menu>
