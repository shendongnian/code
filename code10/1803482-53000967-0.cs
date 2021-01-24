     <ListView>
            <ListView.View>
                <GridView>
                    <GridViewColumn>
                        <GridViewColumn.CellTemplate>
                            <DataTemplate>
                                <Grid>
                                    <CheckBox />
                                </Grid>
                            </DataTemplate>
                        </GridViewColumn.CellTemplate>
                    </GridViewColumn>
                    <GridViewColumn
                        Width="50"
                        DisplayMemberBinding="{Binding ProfileID}"
                        Header="Profile ID" />
                    <GridViewColumn Width="90" Header="Monitor 1">
                        <GridViewColumn.CellTemplate>
                            <DataTemplate>
                                <Grid>
                                    <Image
                                        Width="50"
                                        Height="40"
                                        Source="{Binding DisplayImage}" />
                                    <TextBlock
                                        HorizontalAlignment="Center"
                                        VerticalAlignment="Center"
                                        Text="{Binding Text1}" />
                                </Grid>
                            </DataTemplate>
                        </GridViewColumn.CellTemplate>
                    </GridViewColumn>
                    <GridViewColumn Width="90" Header="Monitor 2">
                        <GridViewColumn.CellTemplate>
                            <DataTemplate>
                                <Grid>
                                    <Image
                                        Width="50"
                                        Height="40"
                                        Source="{Binding DisplayImage}" />
                                    <TextBlock
                                        HorizontalAlignment="Center"
                                        VerticalAlignment="Center"
                                        Text="{Binding Text2}" />
                                </Grid>
                            </DataTemplate>
                        </GridViewColumn.CellTemplate>
                    </GridViewColumn>
                    <GridViewColumn Width="90" Header="Monitor 3">
                        <GridViewColumn.CellTemplate>
                            <DataTemplate>
                                <Grid>
                                    <Image
                                        Width="50"
                                        Height="40"
                                        Source="{Binding DisplayImage}" />
                                    <TextBlock
                                        HorizontalAlignment="Center"
                                        VerticalAlignment="Center"
                                        Text="{Binding Text3}" />
                                </Grid>
                            </DataTemplate>
                        </GridViewColumn.CellTemplate>
                    </GridViewColumn>
                </GridView>
            </ListView.View>
        </ListView>
