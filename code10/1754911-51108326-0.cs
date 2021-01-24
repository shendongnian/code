    <ListView ItemsSource="{x:Bind ShopList}">
        <ListView.ItemTemplate>
            <DataTemplate x:DataType="local:ShopItem">
                <UserControl>
                    <Button Click="Button_Click">
                        <VisualStateManager.VisualStateGroups>
                            <VisualStateGroup x:Name="AvailableStates">
                                <VisualState x:Name="Default"/>
                                <VisualState x:Name="Available">
                                    <VisualState.Setters>
                                        <Setter Target="ItemGrid.Background" Value="Green"/>
                                        <Setter Target="ItemImage.Source" Value="/Assets/Tick.png"/>
                                    </VisualState.Setters>
                                    <VisualState.StateTriggers>
                                        <StateTrigger IsActive="{x:Bind IsBookAvailable, Mode=OneWay}"/>
                                    </VisualState.StateTriggers>
                                </VisualState>
                            </VisualStateGroup>
                        </VisualStateManager.VisualStateGroups>
                        <Grid x:Name="ItemGrid">
                            <TextBlock Foreground="Black" FontWeight="Bold" Text="{x:Bind Title}"/>
                            <Image x:Name="ItemImage" Source="/Assets/NotAvailable.png" Stretch="None" />
                        </Grid>
                    </Button>
                </UserControl>
            </DataTemplate>
        </ListView.ItemTemplate>
    </ListView>
