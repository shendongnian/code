                <DataGridTemplateColumn Header="Status" MinWidth="512.5">
                    <DataGridTemplateColumn.CellTemplate>
                        <DataTemplate>
                            <TextBlock Text="{Binding STATUS}"></TextBlock>
                        </DataTemplate>
                    </DataGridTemplateColumn.CellTemplate>
                    <DataGridTemplateColumn.CellEditingTemplate>
                        <DataTemplate>
                            <ComboBox SelectedValue="{Binding STATUS, Mode=OneWayToSource, UpdateSourceTrigger=PropertyChanged}"
                                      SelectedValuePath="Tag">
                                <ComboBoxItem Content="GREEN" Tag="GREEN"/>
                                <ComboBoxItem Content="YELLOW" Tag="YELLOW"/>
                                <ComboBoxItem Content="ORANGE" Tag="ORANGE"/>
                                <ComboBoxItem Content="RED" Tag="RED"/>
                            </ComboBox>
                        </DataTemplate>
                    </DataGridTemplateColumn.CellEditingTemplate>
                </DataGridTemplateColumn>
