    <TabControl ItemsSource="{Binding ViewModelCollection}"
             Background="Transparent">
        <TabControl.ItemTemplate>
            <DataTemplate>
                <TextBlock Text="{Binding TabTitle}" />
            </DataTemplate>
        </TabControl.ItemTemplate>
        <TabControl.ContentTemplate>
            <DataTemplate>
                <ContentControl Content={Binding} />
            </DataTemplate>
        </TabControl.ContentTemplate>
    </TabControl>
