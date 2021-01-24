    <GridView x:Name="gridview"
                IsItemClickEnabled="True"
                IsTapEnabled="True"
                IsSwipeEnabled="False"
                CanDragItems="False"
                SelectionMode="Single">
            <GridView.ItemTemplate>
                <DataTemplate >
                    <Grid x:Name="MyGrid">
                        <FlyoutBase.AttachedFlyout>
                            <Flyout local:BindableFlyout.ItemsSource="{Binding menuItems}">
                                <local:BindableFlyout.ItemTemplate>
                                    <DataTemplate>
                                        <MenuFlyoutItem Text="{Binding Text}" />
                                    </DataTemplate>
                                </local:BindableFlyout.ItemTemplate>
                            </Flyout>
                        </FlyoutBase.AttachedFlyout>
                        <TextBlock Text="{Binding item}"></TextBlock>
                        <i:Interaction.Behaviors>
                            <core:EventTriggerBehavior EventName="RightTapped">
                                <core:InvokeCommandAction Command="{Binding relayCommand}" CommandParameter="{Binding ElementName=MyGrid}"/>
                            </core:EventTriggerBehavior>
                        </i:Interaction.Behaviors>
                    </Grid>
                </DataTemplate>
            </GridView.ItemTemplate>
        </GridView>
