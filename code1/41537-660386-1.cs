    <ItemsControl ItemsSource="{Binding Source={StaticResource src}, XPath=/Automobiles/Automobile}">
            <ItemsControl.ItemTemplate>
                <DataTemplate>
                    <Grid>
                        <StackPanel Orientation="Horizontal">
                            <StackPanel.ContextMenu>
                                <ContextMenu ItemsSource="{Binding XPath=Suvs}">
                                    <ContextMenu.ItemTemplate>
                                        <DataTemplate>
                                            <StackPanel Orientation="Horizontal">
                                                <TextBlock Text="SUV ID: " />
                                                <TextBlock Text="{Binding XPath=SuvId}" />
                                            </StackPanel>
                                        </DataTemplate>
                                    </ContextMenu.ItemTemplate>
                                </ContextMenu>
                            </StackPanel.ContextMenu>
                            <StackPanel.ToolTip>
                                <ListBox ItemsSource="{Binding XPath=Suvs/SuvId}">
                                    <ListBox.ItemTemplate>
                                        <DataTemplate>
                                            <StackPanel Orientation="Horizontal">
                                                <TextBlock Text="SUV ID: " />
                                                <TextBlock Text="{Binding InnerText, StringFormat={}}" />
                                            </StackPanel>
                                        </DataTemplate>
                                    </ListBox.ItemTemplate>
                                </ListBox>
                            </StackPanel.ToolTip>
                            <TextBlock Text="Make: " />
                            <TextBlock Text="{Binding XPath=MakeName}" />
                        </StackPanel>
                    </Grid>
                </DataTemplate>
            </ItemsControl.ItemTemplate>
