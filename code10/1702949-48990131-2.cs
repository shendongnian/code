    <DataGrid ItemsSource="{Binding Entries}" AutoGenerateColumns="False" IsReadOnly="False" CanUserAddRows="False">
        <DataGrid.Columns>
            <DataGridCheckBoxColumn Binding="{Binding IsChecked, UpdateSourceTrigger=PropertyChanged}">
                <DataGridCheckBoxColumn.HeaderTemplate>
                    <DataTemplate>
                        <CheckBox IsChecked="{Binding RelativeSource={RelativeSource Mode=FindAncestor, AncestorType=local:MainWindow}, Path=ViewModel.AllSelected}">Select All</CheckBox>
                    </DataTemplate>
                </DataGridCheckBoxColumn.HeaderTemplate>
            </DataGridCheckBoxColumn>
        </DataGrid.Columns>
    </DataGrid>
