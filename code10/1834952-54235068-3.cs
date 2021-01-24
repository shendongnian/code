     <ListView Name="test2" HorizontalContentAlignment="Stretch" ItemsSource="{Binding Items}">
                <ListView.View>
                    <GridView>
                        <GridView.Columns>
                            <GridViewColumn Header="Column1">
                                <GridViewColumn.CellTemplate>
                                    <DataTemplate>
                                        <TextBlock Text="{Binding Title}"></TextBlock>
                                    </DataTemplate>
                                </GridViewColumn.CellTemplate>
                            </GridViewColumn>
                            <GridViewColumn Header="Column2">
                                <GridViewColumn.CellTemplate>
                                    <DataTemplate>
                                        <TextBlock Text="{Binding Test}"></TextBlock>
                                    </DataTemplate>
                                </GridViewColumn.CellTemplate>
                            </GridViewColumn>
                        </GridView.Columns>
                    </GridView>
                </ListView.View>
            </ListView>
