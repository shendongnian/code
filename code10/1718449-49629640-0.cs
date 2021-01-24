    <DataGrid Name="ReferenceDataGrid" ItemsSource="{Binding Items}" AutoGenerateColumns="False" RowHeaderWidth="0" IsReadOnly="True">
        <DataGrid.Resources>
            <Style TargetType="DataGridRow">
                <Setter Property="ContextMenu">
                    <Setter.Value>
                        <ContextMenu  DataContext="{Binding Path=DataContext, Source={x:Reference ReferenceDataGrid}}">
                            <MenuItem Header="Delete"  Command="{Binding DeleteCommand}" />
                        </ContextMenu>
                    </Setter.Value>
                </Setter>
            </Style>
        </DataGrid.Resources>
