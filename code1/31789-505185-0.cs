    <Label Tag="{Binding RelativeSource={RelativeSource FindAncestor, AncestorType={x:Type TreeView}}}">
        <Label.ContextMenu>
            <ContextMenu>
                <MenuItem Header="Delete" Command="{x:Static local:Commands.DeleteCommand}"
                          CommandParameter="{Binding PlacementTarget.Tag,
                                                     RelativeSource={RelativeSource FindAncestor,
                                                                                    AncestorType={x:Type ContextMenu}}}"/>
            </ContextMenu>
        </Label.ContextMenu>
    </Label>
