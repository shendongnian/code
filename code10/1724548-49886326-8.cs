    <DataGrid
        ItemsSource="{Binding Data}"
        AutoGeneratingColumn="DataGrid_AutoGeneratingColumn"
        >
        <DataGrid.ColumnHeaderStyle>
            <Style TargetType="DataGridColumnHeader">
                <Setter Property="ContentTemplate">
                    <Setter.Value>
                        <DataTemplate>
                            <ComboBox
                                ItemsSource="{Binding ColumnNames}"
                                SelectedItem="{Binding ColumnName}"
                                />
                        </DataTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
        </DataGrid.ColumnHeaderStyle>
    </DataGrid>
