    <Window
    ...blah blah blah...
    DataContext="{Binding Main, Source={StaticResource Locator}}"
    >
    <Grid>
        <TabControl>
            <TabItem DataContext="{Binding Tab, Source={StaticResource Locator}}" Header="TabItem">
                <StackPanel>
                    <Label Content="{Binding DataContext.Zoom, RelativeSource={RelativeSource Mode=FindAncestor, AncestorType={x:Type Window}}}" />
                    <Label Content="{Binding Zoom}" />
                </StackPanel>
            </TabItem>
        </TabControl>
    </Grid>
