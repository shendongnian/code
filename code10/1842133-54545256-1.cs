    <DataGrid x:Name="DGRunInfoItems"  IsReadOnly="True" ColumnWidth="*" FontSize="{StaticResource BRControlNormalFontSize}" ScrollViewer.VerticalScrollBarVisibility="Auto" HeadersVisibility="None" CanUserAddRows="False" ItemsSource="{Binding RunViewModel.RunInfoDataTable}" AutoGenerateColumns="False">
                        <DataGrid.CellStyle>
                            <Style TargetType="{x:Type DataGridCell}">
                                <Style.Triggers>
                                    <Trigger Property="DataGridCell.IsSelected" Value="True">
                                        <Setter Property="BorderBrush">
                                            <Setter.Value>
                                                <SolidColorBrush Color="Transparent"/>
                                            </Setter.Value>
                                        </Setter>
                                        <Setter Property="Foreground"
                                Value="{DynamicResource
                                       {x:Static SystemColors.ControlTextBrushKey}}"/>
                                        <Setter Property="Background">
                                            <Setter.Value>
                                                <SolidColorBrush Color="Transparent"/>
                                            </Setter.Value>
                                        </Setter>
                                    </Trigger>
                                </Style.Triggers>
                            </Style>
                        </DataGrid.CellStyle>
                        <DataGrid.Columns>
                            <DataGridTextColumn Binding="{Binding Header}" FontWeight="Bold">
                            </DataGridTextColumn>
                            <DataGridTextColumn Binding="{Binding Value}"></DataGridTextColumn>
                        </DataGrid.Columns>
                        <DataGrid.RowStyle>
                            <Style TargetType="DataGridRow">
                                <Setter Property="MinHeight" Value="28"/>
                            </Style>
                        </DataGrid.RowStyle>
                    </DataGrid> 
