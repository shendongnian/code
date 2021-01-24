    <Grid>
            <ItemsControl ItemsSource = "{Binding listCategoryAddValue}" >
                <ItemsControl.ItemTemplate>
                    <DataTemplate>
                        <StackPanel>
                            <StackPanel Orientation="Horizontal">
                                <Button Content="Add Value" Command="{Binding Path=AddValue}"/> 
                                <TextBlock Text="{Binding Category.Name}"/>
                            </StackPanel>
                            <ListBox ItemsSource="{Binding ValueList}" />
                        </StackPanel>
                    </DataTemplate>
                </ItemsControl.ItemTemplate>
                <ItemsControl.ItemsPanel>
                    <ItemsPanelTemplate>
                        <StackPanel Orientation="Horizontal">
                        </StackPanel>
                    </ItemsPanelTemplate>
                </ItemsControl.ItemsPanel>
            </ItemsControl>
        </Grid>
