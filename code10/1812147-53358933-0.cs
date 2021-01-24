     <DataGrid.Columns>
                        <DataGridTextColumn Header="1">
                            <DataGridTextColumn.HeaderTemplate>
                                <DataTemplate>
                                    <Grid MinWidth="200">
                                        <Grid.ColumnDefinitions>
                                            <ColumnDefinition/>
                                            <ColumnDefinition/>
                                            <ColumnDefinition/>
                                        </Grid.ColumnDefinitions>
                                        <Grid.RowDefinitions>
                                            <RowDefinition/>
                                            <RowDefinition/>
                                        </Grid.RowDefinitions>
                                        <TextBlock Text="header" Grid.ColumnSpan="3" HorizontalAlignment="Center"></TextBlock>
                                        <TextBlock Grid.Row="1" Text="col"/>
                                        <TextBlock Grid.Row="1" Grid.Column="1" Text="col1"/>
                                        <TextBlock Grid.Row="1" Grid.Column="2" Text="col2"/>
                                    </Grid>
                                </DataTemplate>
                            </DataGridTextColumn.HeaderTemplate>
                        </DataGridTextColumn>
                        <DataGridTextColumn Header="2"></DataGridTextColumn>
        </DataGrid.Columns>
