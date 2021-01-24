    <ItemsControl ItemsSource="{Binding ColOfCol}" AlternationCount="2147483647">
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <ItemsControl ItemsSource="{Binding }" AlternationCount="2147483647">
                    <ItemsControl.ItemTemplate>
                        <DataTemplate>
                            <StackPanel Orientation="Horizontal">
                                <TextBlock Text="{Binding Path=(ItemsControl.AlternationIndex), RelativeSource={RelativeSource AncestorType=ContentPresenter, AncestorLevel=2}, Converter={StaticResource Convert}}"/>
                                <TextBlock Text="{Binding Path=(ItemsControl.AlternationIndex), RelativeSource={RelativeSource AncestorType=ContentPresenter, AncestorLevel=1}, Converter={StaticResource Convert}}"/>
                            </StackPanel>
                        </DataTemplate>
                    </ItemsControl.ItemTemplate>
                </ItemsControl>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
