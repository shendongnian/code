    <TabControl ItemsSource="{Binding TabItems}">
        <TabControl.Resources>
            <Style TargetType="{x:Type TabItem}">
                <Setter Property="IsSelected" Value="{Binding IsSelected, Mode=TwoWay}"/>
            </Style>
            <DataTemplate DataType="{x:Type local:DisplayModel1}">
                <local:DisplayModel1View />
            </DataTemplate>
            <DataTemplate DataType="{x:Type local:DisplayModel2}">
                <local:DisplayModel2View />
            </DataTemplate>
        </TabControl.Resources>
        <TabControl.ItemTemplate>
            <DataTemplate DataType="{x:Type local:TabModel}">
                <Label DockPanel.Dock="Left" Content="{Binding Name}"></Label>
            </DataTemplate>
        </TabControl.ItemTemplate>
        <TabControl.ContentTemplate>
            <DataTemplate DataType="{x:Type local:BaseModel}">
                <ContentControl Content="{Binding ViewModel}"/>
            </DataTemplate>
        </TabControl.ContentTemplate>
    </TabControl>
