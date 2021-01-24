    <ScrollViewer>
            <Grid x:Name="mainGrid" Margin="10,10,10,10">
                <DataGrid x:Name="appSettingsData" AutoGenerateColumns="False" Grid.ColumnSpan="6" Grid.Row="7" CanUserAddRows="False" >
                    <DataGrid.Columns>
                        <DataGridTemplateColumn Header="Value" Width="*">
                            <DataGridTemplateColumn.CellTemplate>
                                <DataTemplate>
                                        <TextBlock Text="{Binding Value}">
                                            <TextBlock.Style>
                                                <Style TargetType="{x:Type TextBlock}">
                                                    <Setter Property="Visibility" Value="Hidden"/>
                                                    <Style.Triggers>
                                                        <DataTrigger Binding="{Binding Type}" Value="textBox">
                                                            <Setter Property="Visibility" Value="Visible"/>
                                                        </DataTrigger>
                                                    </Style.Triggers>
                                                </Style>
                                            </TextBlock.Style>
                                        </TextBlock>
                                </DataTemplate>
                            </DataGridTemplateColumn.CellTemplate>
                        </DataGridTemplateColumn>
                    </DataGrid.Columns>
                </DataGrid>
            </Grid>
    </ScrollViewer>
