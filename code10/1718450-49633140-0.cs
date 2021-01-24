    <DataGrid 
        ItemsSource="{Binding Users}" 
        Background="White" 
        Name="dg"
        SelectedItem="{Binding SelectedUser}"
              >
        <DataGrid.Resources>
            <ContextMenu x:Key="dgContextMenu"
                         DataContext="{Binding DataContext, RelativeSource={RelativeSource AncestorType=DataGrid}}">
                <MenuItem Header="Up" Command="{Binding UpCommand}" />
            </ContextMenu>
        </DataGrid.Resources>
        <DataGrid.RowStyle>
            <Style TargetType="{x:Type DataGridRow}">
                <Setter Property="ContextMenu" Value="{StaticResource dgContextMenu}"/>
