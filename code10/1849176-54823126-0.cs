    <ItemsControl ItemsSource="{Binding Messages}">
        <ItemsControl.ItemContainerStyle>
            <Style TargetType="ContentPresenter">
                <Setter Property="ContentTemplate">
                    <Setter.Value>
                        <DataTemplate>
                            <StackPanel>
                                <TextBlock Text="{Binding Name}"/>
                                <TextBlock Text="{Binding Text}"/>
                            </StackPanel>
                        </DataTemplate>
                    </Setter.Value>
                </Setter>
                <Style.Triggers>
                    <DataTrigger Binding="{Binding IsImage}" Value="True">
                        <Setter Property="ContentTemplate">
                            <Setter.Value>
                                <DataTemplate>
                                    <Image Source="{Binding Image}"/>
                                </DataTemplate>
                            </Setter.Value>
                        </Setter>
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </ItemsControl.ItemContainerStyle>
    </ItemsControl>
