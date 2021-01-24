     <DataGridTemplateColumn>
                                    <DataGridTemplateColumn.CellTemplate>
                                        <DataTemplate>
                                            <Expander Style="{StaticResource PlusMinusExpanderStyle}"
                                                      ToolTip="Rule Details"
                                                      Visibility="{Binding ISMonitorExanderVisible, Converter={StaticResource BooleanToVisibilityConverter}, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}"
                                                      >
                                                <Expander.IsExpanded>
                                                    <Binding RelativeSource="{RelativeSource AncestorType={x:Type DataGridRow}}"
                                                             Path="DetailsVisibility"
                                                             Mode="TwoWay">
                                                        <Binding.Converter>
                                                            <converters:BooleanToVisibilityDataGridRow FalseToVisibility="Collapsed" />
                                                        </Binding.Converter>
                                                    </Binding>
                                                </Expander.IsExpanded>
                                            </Expander>
                                        </DataTemplate>
                                    </DataGridTemplateColumn.CellTemplate>
                                </DataGridTemplateColumn>
