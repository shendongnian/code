    <TreeView Grid.IsSharedSizeScope="True" 
              ItemsSource="{Binding Xml.Elements}">
        <TreeView.ItemTemplate>
            <HierarchicalDataTemplate ItemsSource="{Binding Elements}">
                <Grid>
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition SharedSizeGroup="Name"/>
                        <ColumnDefinition SharedSizeGroup="Value"/>
                    </Grid.ColumnDefinitions>
                    <Label Content="{Binding Name}" />
                    <!--Show TextBox only for leaf elements-->
                    <TextBox Grid.Column="1"
                             Text="{Binding Value}" 
                             Visibility="{Binding HasElements,
                                Converter={StaticResource reverseBoolToVisibilityConverter}}"/>
                </Grid>
            </HierarchicalDataTemplate>
        </TreeView.ItemTemplate>
    </TreeView>
