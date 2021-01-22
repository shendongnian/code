    <TabControl
        ItemsSource="{Binding Items}"
        SelectedItem="{Binding SelectedItem}">
        <TabControl.DataContext>
            <local:ItemsCollection/>
        </TabControl.DataContext>
        <TabControl.Resources>
            <DataTemplate DataType="{x:Type local:Item}">
                <TextBlock Background="AliceBlue" Text="{Binding Text}"/>
            </DataTemplate>
        </TabControl.Resources>
        <TabControl.ItemContainerStyle>
            <Style TargetType="{x:Type TabItem}">
                <Style.Setters>
                    <Setter Property="Header" Value="{Binding Text}"/>
                </Style.Setters>
            </Style>
        </TabControl.ItemContainerStyle>
    </TabControl>
