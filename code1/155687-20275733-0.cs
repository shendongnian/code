    <DataGrid.ContextMenu>
         <ContextMenu>
               <MenuItem Header="MyHeader" 
                         Command="{Binding MyCommand}"
                         CommandParameter="{Binding RelativeSource={RelativeSource FindAncestor, AncestorType={x:Type ContextMenu}}, Path=PlacementTarget.SelectedItem}" />
    </DataGrid.ContextMenu>
