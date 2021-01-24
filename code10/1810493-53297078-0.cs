    <DataGrid ItemsSource="{Binding YourItemsCollection}" AutoGenerateColumns="false" AlternationCount="{Binding YourItemsCollection.Count}">
        <DataGrid.CellStyle>
            <Style TargetType="DataGridCell">
                <Style.Triggers>
                    <MultiDataTrigger>
                        <MultiDataTrigger.Conditions>
                            <Condition Binding="{Binding Column.DisplayIndex, RelativeSource={RelativeSource Self}}" Value="0"/>
                            <Condition Binding="{Binding AlternationIndex, RelativeSource={RelativeSource AncestorType=DataGridRow}}" Value="0"/>
                        </MultiDataTrigger.Conditions>
                        <MultiDataTrigger.Setters>
                            <Setter Property="IsEnabled" Value="False" />
                        </MultiDataTrigger.Setters>
                    </MultiDataTrigger>
                </Style.Triggers>
            </Style>
        </DataGrid.CellStyle>
    </DataGrid>
