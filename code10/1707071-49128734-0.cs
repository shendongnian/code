    <DataGrid Name="dg" Width="400" Height="300" AutoGenerateColumns="False">
            <DataGrid.Columns>
                <DataGridTextColumn Binding="{Binding Name}"/>
                <DataGridTemplateColumn Header="Value" Width="*">
                    <DataGridTemplateColumn.CellTemplate>
                        <DataTemplate>
                            <ComboBox Height="22" Name="comboBox1">
                                <ComboBoxItem Content="X"/>
                                <ComboBoxItem Content="Y"/>
                                <ComboBoxItem Content="Z"/>
                            </ComboBox>
                        </DataTemplate>
                    </DataGridTemplateColumn.CellTemplate>
                </DataGridTemplateColumn>
            </DataGrid.Columns>
    </DataGrid>
