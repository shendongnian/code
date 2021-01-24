    <CollectionViewSource x:Key='key' Source="{Binding Source={StaticResource MyData}}">
            <CollectionViewSource.GroupDescriptions>
                <PropertyGroupDescription PropertyName="@Catalog" />
            </CollectionViewSource.GroupDescriptions>
        </CollectionViewSource>
    </Window.Resources>
    <ListView ItemsSource='{Binding Source={StaticResource key}}' BorderThickness="0,0,0,0">
        <ListView.GroupStyle>
            <GroupStyle>
                <GroupStyle.ContainerStyle>
                    <Style TargetType="{x:Type GroupItem}">
                        <Setter Property="Margin" Value="0,0,0,5"/>
                        <Setter Property="Template">
                            <Setter.Value>
                                <ControlTemplate TargetType="{x:Type GroupItem}">
                                    <Expander IsExpanded="True"
                                              BorderBrush="Gray"
                                              BorderThickness="0,0,0,1">
                                        <Expander.Header>
                                            <DockPanel>
                                                <TextBlock  Text="{Binding Path=Name}" Margin="5,0,0,0" Width="100"/>
                                                <TextBlock  Text="{Binding Path=Item}"/>
                                            </DockPanel>
                                        </Expander.Header>
                                        <Expander.Content>
                                            <ItemsPresenter />
                                        </Expander.Content>
                                    </Expander>
                                </ControlTemplate>
                            </Setter.Value>
                        </Setter>
                    </Style>
                </GroupStyle.ContainerStyle>
            </GroupStyle>
        </ListView.GroupStyle>
        <ListView.View>
            <GridView>
                <GridViewColumn Header="ID"
                        DisplayMemberBinding="{Binding ID}"
                        Width="100" />
                <GridViewColumn Header="Titel"
                        DisplayMemberBinding="{Binding This}"
                        Width="100" />
                <GridViewColumn Header="Date"
                        DisplayMemberBinding="{Binding Should}"
                        Width="100" />
                <GridViewColumn Header="Something"
                        DisplayMemberBinding="{Binding Work}"
                        Width="100" />
            </GridView>
        </ListView.View>
    </ListView>
