    <ItemsControl x:Name="Row" Grid.Row="4" ItemsSource={ Binding Values }>
        <ItemsControl.ItemsPanel>
            <ItemsPanelTemplate>
                <StackPanel/>
            </ItemsPanelTemplate>
        </ItemsControl.ItemsPanel>
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <Button Content="{Binding }" 
            Command="{Binding ButtonClickCommand}"
            CommandParameter="{Binding RelativeSource={RelativeSource Self}, Path=Content}"/>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl >
