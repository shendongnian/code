    <ItemsControl x:Name="Row" Grid.Row="4" ItemsSource="{Binding Values}">
        <ItemsControl.ItemsPanel>
            <ItemsPanelTemplate>
                <StackPanel/>
            </ItemsPanelTemplate>
        </ItemsControl.ItemsPanel>
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <Button Content="{Binding }" 
                    Command="{Binding Path=DataContext.ButtonClickCommand, RelativeSource={RelativeSource AncestorType=ItemsControl}}" 
                    CommandParameter="{Binding }"/>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
