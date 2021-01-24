    <Grid>
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="25*" />
            <ColumnDefinition Width="75*" />
        </Grid.ColumnDefinitions>
        <TreeView x:Name="trv" Grid.Column="0" ItemsSource="{Binding Groups}">
            <TreeView.ItemTemplate>
                <HierarchicalDataTemplate ItemsSource="{Binding Parameters}">
                    <TextBlock Text="{Binding GroupName}" />
                    <HierarchicalDataTemplate.ItemTemplate>
                        <DataTemplate>
                            <StackPanel Orientation="Horizontal">
                                <TextBlock Text="{Binding ParameterName}"></TextBlock>
                            </StackPanel>
                        </DataTemplate>
                    </HierarchicalDataTemplate.ItemTemplate>
                </HierarchicalDataTemplate>
            </TreeView.ItemTemplate>
        </TreeView>
        <ListView Grid.Column="1" 
                  Background="Bisque" 
                  ItemsSource="{Binding SelectedItem.Values, ElementName=trv}">
            <ListView.View>
                <GridView>
                    <GridViewColumn Header="Date Time" DisplayMemberBinding="{Binding DateTimeValue}"/>
                    <GridViewColumn Header="Value" DisplayMemberBinding="{Binding Value}"/>
                </GridView>
            </ListView.View>
        </ListView>
    </Grid>
