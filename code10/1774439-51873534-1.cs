    <DataGrid x:Name="TheGrid" ItemsSource="{Binding Source={StaticResource MessageItems}}" KeyUp="MessageList_KeyUp" AutoGenerateColumns="False" IsReadOnly="True" ColumnWidth="Auto">
        <DataGrid.Tag>
            <Binding Path="." RelativeSource="{RelativeSource AncestorType=Window}" />
        </DataGrid.Tag>
        <DataGrid.ContextMenu>
            <ContextMenu>
                <MenuItem Header="Set Service" Command="{Binding  PlacementTarget.Tag.SetService, RelativeSource={RelativeSource AncestorType=ContextMenu}}"/>
            </ContextMenu>
        </DataGrid.ContextMenu>
    </DataGrid>
