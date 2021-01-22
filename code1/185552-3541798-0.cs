        <TabControl ItemsSource="{Binding EmpList }">
            <TabControl.ItemTemplate>
                <DataTemplate>
                    <TextBlock Text="{Binding FirstName }"></TextBlock>
                </DataTemplate>
            </TabControl.ItemTemplate>
        </TabControl>
