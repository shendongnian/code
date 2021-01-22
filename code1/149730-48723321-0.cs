    <Window.Resources>
        <ContextMenu x:Key="ColumnHeaderMenu">
            <MenuItem Header="Header Option 1"/>
            <MenuItem Header="Header Option 2"/>
        </ContextMenu>
        <ContextMenu x:Key="RowMenu">
            <MenuItem Header="Row Option 1"/>
            <MenuItem Header="Row Option 2"/>
        </ContextMenu>
    </Window.Resources>
    <Grid>
        <DataGrid ItemsSource="{Binding memberList}" AutoGenerateColumns="True">
            <DataGrid.ColumnHeaderStyle>
                <Style TargetType="DataGridColumnHeader">
                    <Setter Property="ContextMenu" Value="{StaticResource ColumnHeaderMenu}"/>
                </Style>
            </DataGrid.ColumnHeaderStyle>
            <DataGrid.RowStyle>
                <Style TargetType="DataGridRow">
                    <Setter Property="ContextMenu" Value="{StaticResource RowMenu}"/>
                </Style>
            </DataGrid.RowStyle>
        </DataGrid>
    </Grid>
