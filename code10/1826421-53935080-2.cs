    <ListView ItemsSource="{x:Bind line_items,Mode=OneWay}"  SelectionChanged="ListView_SelectionChanged">
            <ListView.ItemTemplate>
                <DataTemplate>
                    <StackPanel Orientation="Horizontal">
                        <CheckBox IsChecked="{Binding is_checked,Mode=OneWay}"></CheckBox>
                        <TextBlock Text="{Binding value,Mode=OneWay}"></TextBlock>
                    </StackPanel>
                </DataTemplate>
            </ListView.ItemTemplate>
        </ListView>
