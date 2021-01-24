    <Grid.ContextMenu>
                <ContextMenu >
                    <ContextMenu.DataContext>
                        <dad:BaseViewModel/>
                    </ContextMenu.DataContext>
    
                    <MenuItem Header="Edit"/>
                    <MenuItem Header="Remove"
                              Command="{Binding CardViewModel.command}"/>
                </ContextMenu>
            </Grid.ContextMenu>
