               <ItemsControl ItemsSource="{Binding RoomColumns}" >
                    <ItemsControl.ItemsPanel>
    
                        <ItemsPanelTemplate>
                            <WrapPanel Orientation="Horizontal" />
                        </ItemsPanelTemplate>
    
                    </ItemsControl.ItemsPanel>
    
                    <ItemsControl.ItemTemplate>
                        <DataTemplate >
                            <ItemsControl ItemsSource="{Binding RoomModel}" >
                                <ItemsControl.ItemsPanel>
    
                                    <ItemsPanelTemplate>
                                        <WrapPanel Orientation="Vertical" />
                                    </ItemsPanelTemplate>
    
                                </ItemsControl.ItemsPanel>
    
                                <ItemsControl.ItemTemplate>
                                    <DataTemplate >
                                        <TextBlock Text="{Binding DisplayedState}" HorizontalAlignment="Center" VerticalAlignment="Center"/>
                                    </DataTemplate>
                                </ItemsControl.ItemTemplate>
                            </ItemsControl>
                        </DataTemplate>
                    </ItemsControl.ItemTemplate>
                </ItemsControl>
