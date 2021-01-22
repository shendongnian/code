    <ItemsControl ItemsSource="{Binding SubSystems}">
      <ItemsControl.ItemTemplate>
        <DataTemplate>
          <Checkbox IsChecked="{Binding IsSelected, Mode=TwoWay}" Content="{Binding Name}" />
        </DataTemplate>
      <ItemsControl.ItemTemplate>
    </ItemsControl>
