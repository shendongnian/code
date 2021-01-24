    <TabControl ItemsSource="{Binding UserControls}">
        <TabControl.ItemTemplate>
            <DataTemplate>
                <TextBlock Text="{Binding Header}" />
            </DataTemplate>
        </TabControl.ItemTemplate>
        <TabControl.ContentTemplate>
            <DataTemplate>
                <local:UCTest />
            </DataTemplate>
        </TabControl.ContentTemplate>
    </TabControl>
