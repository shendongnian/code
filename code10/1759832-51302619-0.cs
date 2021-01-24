    <TabControl.ContentTemplate>
        <DataTemplate>
            <ScrollViewer VerticalScrollBarVisibility="Auto" HorizontalScrollBarVisibility="Auto">
                <ItemsControl ItemsSource="{Binding Content}">
                    <ContentControl Content="{Binding}" />
                </ItemsControl>
            </ScrollViewer>
        </DataTemplate>
    </TabControl.ContentTemplate>
