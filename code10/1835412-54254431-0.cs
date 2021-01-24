    <ListView x:Name="lsttest" ItemsSource="{Binding persons}">
            <ListViewItem>
                <StackPanel>
                    <ListView>
                        <ListView.View>
                            <GridView>
                                <GridViewColumn Header="#1" Width="50">
                                    <GridViewColumn.CellTemplate>
                                        <DataTemplate>
                                            <TextBlock Text="{Binding Name}"
                                               Width="20" TextAlignment="Left" Margin="5" VerticalAlignment="Top" />
                                        </DataTemplate>
                                    </GridViewColumn.CellTemplate>
                                </GridViewColumn>
                                <GridViewColumn Header="Test 2" Width="50">
                                    <GridViewColumn.CellTemplate>
                                        <DataTemplate>
                                            <TextBlock Text="{Binding Name}"
                                               Width="20" TextAlignment="Left" Margin="5" VerticalAlignment="Top" />
                                        </DataTemplate>
                                    </GridViewColumn.CellTemplate>
                                </GridViewColumn>
                            </GridView>
                        </ListView.View>
                    </ListView>
                    <Expander ToolTip="Expand" ExpandDirection="Down" Foreground="Black" VerticalAlignment="Top">
                        <Expander.Header>
                            <TextBlock Text="{Binding Model.Name, Mode=OneWay}"
                                               HorizontalAlignment="{Binding HorizontalAlignment, RelativeSource={RelativeSource AncestorType=ContentPresenter}, Mode=OneWayToSource}"
                                               TextAlignment="Left" Margin="5" TextWrapping="Wrap" VerticalAlignment="Top" />
                        </Expander.Header>
                        <GroupBox Header="Description" FontWeight="Bold" Width="{Binding ActualWidth, ElementName=lsttest}">
                            <TextBlock Text="{Binding Name, Mode=OneWay}" TextWrapping="Wrap"
                                                       FontWeight="Normal" TextAlignment="Left" Margin="5" />
                        </GroupBox>
                    </Expander>
                </StackPanel>
            </ListViewItem>
            </ListView>
