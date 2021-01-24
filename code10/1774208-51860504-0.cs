    <TabControl Background="{x:Null}" x:Name="MyView" ItemsSource="{Binding MyControls}">
        <TabControl.ItemTemplate>
            <DataTemplate>
                <TextBlock Text="{Binding Title}" />
            </DataTemplate>
        </TabControl.ItemTemplate>
    </TabControl>
