    <Grid.ContextMenu>
            <ContextMenu>
                <MenuItem Header="Edit"/>
                <MenuItem Header="Remove"
                          Command="{Binding DataContext.CardViewModel.command, RelativeSource={RelativeSource Mode=FindAncestor, AncestorType={x:Type MainView}}"/>
            </ContextMenu>
        </Grid.ContextMenu>
