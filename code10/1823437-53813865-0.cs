    <GridViewColumn Header="{x:Static p:Resources.Name}" Width="100">
        <GridViewColumn.CellTemplate>
            <DataTemplate>
                <Grid>
                    <TextBlock Text="{Binding Path=Name}" Tag="{Binding Name}"/>
                    <Rectangle Fill="Transparent" ToolTipService.ToolTip="Text="{Binding Path=ToolTipModifications}" MouseEnter="UIElement_OnMouseEnter"/>
                </Grid>
            </DataTemplate>
        </GridViewColumn.CellTemplate>
    </GridViewColumn>
