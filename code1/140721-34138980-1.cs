    <ItemsControl ItemsSource="{Binding Numbers}" AlternationCount="{Binding RelativeSource={RelativeSource Self}, Path=Items.Count}">
        <ItemsControl.ItemsPanel>
            <ItemsPanelTemplate>
                <StackPanel Orientation="Horizontal"/>
            </ItemsPanelTemplate>
        </ItemsControl.ItemsPanel>
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <StackPanel Orientation="Horizontal">
                    <TextBlock x:Name="SeparatorTextBlock" Text=", "/>
                    <TextBlock Text="{Binding .}"/>
                </StackPanel>
            <DataTemplate.Triggers>
                <Trigger Property="ItemsControl.AlternationIndex" Value="0">
                    <Setter Property="Visibility" TargetName="SeparatorTextBlock" Value="Collapsed" />
                </Trigger>
             </DataTemplate.Triggers>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
