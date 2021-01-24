    <Window.DataContext>
        <local:MainWindowViewModel/>
    </Window.DataContext>
    <Grid>
        <TreeView ItemsSource="{Binding Parents}">
            <TreeView.Resources>
                <HierarchicalDataTemplate DataType="{x:Type local:Parent}" ItemsSource="{Binding Children}">
                        <TextBlock Text="{Binding Name}" />
                </HierarchicalDataTemplate>
                <DataTemplate DataType="{x:Type local:Child}">
                    <StackPanel Tag="{Binding DataContext, 
                            RelativeSource={RelativeSource AncestorType=TreeViewItem , AncestorLevel=2}
                            }" 
                           >
                        <StackPanel.ContextMenu>
                            <ContextMenu DataContext="{Binding Path=PlacementTarget.Tag,
                                         RelativeSource={x:Static RelativeSource.Self}}">
                                <MenuItem Header="Delete"  Command="{Binding DeleteCommand}">
                                </MenuItem>
                            </ContextMenu>
                        </StackPanel.ContextMenu>
                        <TextBlock Text="{Binding ChildName}"/>
                    </StackPanel>
                </DataTemplate>
            </TreeView.Resources>
        </TreeView>
    </Grid>
