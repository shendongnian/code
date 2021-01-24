    <ListBox
                            Name="memberCollection"
                            Grid.Row="0"
                            MinWidth="150"
                            HorizontalAlignment="Stretch"
                            VerticalAlignment="Stretch"
                            BorderThickness="0"
                            ItemsSource="{Binding MainValues}">
        <ListBox.GroupStyle>
            <GroupStyle>
                <GroupStyle.ContainerStyle>
                    <Style TargetType="{x:Type GroupItem}">
                        <Setter Property="Template">
                            <Setter.Value>
                                <ControlTemplate>
                                    <Expander IsExpanded="True">
                                        <Expander.Header>
                                            <StackPanel Orientation="Horizontal">
                                                <TextBlock Text="{Binding Name}" FontWeight="Bold" />
                                            </StackPanel>
                                        </Expander.Header>
                                        <ItemsPresenter />
                                    </Expander>
                                </ControlTemplate>
                            </Setter.Value>
                        </Setter>
                    </Style>
                </GroupStyle.ContainerStyle>
            </GroupStyle>
        </ListBox.GroupStyle>
        <ListBox.ItemTemplate>
            <DataTemplate>
                <ItemsControl ItemsSource="{Binding Values}">
                    <ItemsControl.ItemTemplate>
                        <DataTemplate>
                            <Label Content="{Binding Name}"/>
                        </DataTemplate>
                    </ItemsControl.ItemTemplate>
                </ItemsControl>
            </DataTemplate>
        </ListBox.ItemTemplate>
    </ListBox>
