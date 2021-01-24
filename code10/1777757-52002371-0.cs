        <TabControl ItemsSource="{Binding TableAreaCollection}">
            <TabControl.ItemTemplate>
                <DataTemplate>
                    <ItemsControl ItemsSource="{Binding TableCollection}">
                        <ItemsControl.ItemsPanel>
                            <ItemsPanelTemplate>
                                <Canvas x:Name="canvas1"/>
                            </ItemsPanelTemplate>
                        </ItemsControl.ItemsPanel>
                        <ItemsControl.ItemTemplate>
                            <DataTemplate DataType="{x:Type vm:TableViewModel}">
                                <Button Uid="{Binding TableName}" ContentStringFormat="{Binding TableGuestCount}"  Style="{StaticResource ResourceKey=BtnTableEmpty}" Width="84" Height="90"  />
                            </DataTemplate>
                        </ItemsControl.ItemTemplate>
                        <ItemsControl.ItemContainerStyle>
                            <Style TargetType="ContentPresenter">
                                <Setter Property="Canvas.Left" Value="{Binding Path=TablePosX}" />
                                <Setter Property="Canvas.Top" Value="{Binding Path=TablePosY}" />
                                <Setter Property="Tag" Value="{Binding Path=TableID}"/>
                            </Style>
                        </ItemsControl.ItemContainerStyle>
                    </ItemsControl>
                </DataTemplate>
            </TabControl.ItemTemplate>
        </TabControl>
