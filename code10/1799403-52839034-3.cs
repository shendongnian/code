        <DataGrid AutoGenerateColumns="False" CanUserAddRows="True" ItemsSource="{Binding Options}">
            <DataGrid.Columns>
                <DataGridTemplateColumn>
                    <DataGridTemplateColumn.CellTemplate>
                        <DataTemplate>
                            <RadioButton IsChecked="{Binding IsChecked}" GroupName="OptionsRad" 
                                         IsEnabled="{Binding Path=Item, RelativeSource={RelativeSource AncestorType=DataGridRow"}, Converter={StaticResource DataToEnabledConverter}}"/>
                        </DataTemplate>
                    </DataGridTemplateColumn.CellTemplate>
                </DataGridTemplateColumn>
                <DataGridTextColumn Header="Option" Binding="{Binding OptionName}"/>
            </DataGrid.Columns>
        </DataGrid>
