    <TabControl ItemsSource="{Binding Groups, Mode=TwoWay}" SelectedItem="{Binding SelectedGroup, Mode=TwoWay}">
        <TabControl.ContentTemplate>
            <DataTemplate>
                <ListBox ItemsSource="{Binding RelativeSource={RelativeSource FindAncestor, AncestorType=TabControl, AncestorLevel=1}, Path=DataContext.ItemsInGroup, Mode=TwoWay}">
                    <ListBox.ItemTemplate>
                        <DataTemplate>
                            <TextBlock Text="{Binding ItemGroup}" />
                        </DataTemplate>
                    </ListBox.ItemTemplate>
                </ListBox>
            </DataTemplate>
        </TabControl.ContentTemplate>
    </TabControl>
