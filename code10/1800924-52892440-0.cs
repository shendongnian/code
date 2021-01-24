    <ControlTemplate x:Key="template" TargetType="UserControl">
        <Border BorderBrush="Black">
            <StackPanel>
                <TextBlock Text="{Binding Header}"/>
                <Button Content="Add" Command="{Binding AddComponentCommand}"/>
                <Button Content="Del" Command="{Binding DeleteComponentCommand}"/>
                <Expander IsExpanded="{Binding IsExpanded, Mode=OneWay}">
                    <ContentPresenter />
                </Expander>
            </StackPanel>
        </Border>
    </ControlTemplate>
    <DataTemplate DataType="{x:Type viewModel:CarViewModel}">
        <UserControl Template="{StaticResource template}">
            <TextBox Text="{Binding Car.Brand}"/>
        </UserControl>
    </DataTemplate>
    <DataTemplate DataType="{x:Type viewModel:PersonViewModel}">
        <UserControl Template="{StaticResource template}">
            <TextBox Text="{Binding Person.Name}"/>
        </UserControl>
    </DataTemplate>
