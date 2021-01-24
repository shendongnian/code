    <ListView x:Name="test" DockPanel.Dock="Top" Margin="10" ItemsSource="{Binding CurrentView}">
                <ListView.ItemTemplate>
                    <DataTemplate DataType="viewModel:ViewModel">
                        <Border BorderBrush="Black" BorderThickness="1" Margin="1">
                            <Expander ToolTip="Expand" ExpandDirection="Down" Foreground="Black">
                                <Expander.Header>
                                    <Grid>
                                        <Grid.ColumnDefinitions>
                                            <ColumnDefinition Width="Auto" />
                                            <ColumnDefinition Width="Auto" />
                                            <ColumnDefinition Width="Auto" />
                                            <ColumnDefinition Width="*" />
                                            <ColumnDefinition Width="Auto" />
                                            <ColumnDefinition Width="Auto" />
                                        </Grid.ColumnDefinitions>
                                        <Grid.RowDefinitions>
                                            <RowDefinition Height="*" />
                                        </Grid.RowDefinitions>
                                        <Label Grid.Column="0">Column 1</Label>
                                        <Label Grid.Column="1">Column 2</Label>
                                        <Label Grid.Column="2">Column 3</Label>
                                        <Label Grid.Column="3">Column 4</Label>
                                        <TextBlock Grid.Column="0" Width="20" Text="{Binding Model.Number, StringFormat='#{0}', Mode=OneWay}" TextAlignment="Left" Margin="5" />
                                        <Image Grid.Column="1" />
                                        <TextBlock Grid.Column="2" TextAlignment="Center" Margin="5" Width="50">
                                <Hyperlink />
                                        </TextBlock>
                                        <TextBlock Grid.Column="3" TextAlignment="Left" Margin="5" TextWrapping="Wrap" />
                                        <TextBlock Grid.Column="4" TextAlignment="Center" Margin="5" Width="100" />
                                        <Button Grid.Column="5" />
                                    </Grid>
                                </Expander.Header>
                            </Expander>
                        </Border>
                    </DataTemplate>
                </ListView.ItemTemplate>
            </ListView>
