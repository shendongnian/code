    <ListView Name="ResultsList" 
                 ItemsSource="{Binding SequenceCollection}">
            <ListView.View>
                <GridView>
                    <GridViewColumn Header="Sequence" Width="450" >
                        <GridViewColumn.CellTemplate>
                            <DataTemplate>
                                <ItemsControl ItemsSource="{Binding Events}">
                                    <ItemsControl.ItemsPanel>
                                       <ItemsPanelTemplate>
                                           <StackPanel Orientation="Horizontal"></StackPanel>
                                       </ItemsPanelTemplate>
                                   </ItemsControl.ItemsPanel>
                                    <ItemsControl.ItemTemplate>
                                        <DataTemplate>
                                            <Border>
                                                <Border.Style>
                                                    <Style TargetType="Border">
                                                        <Style.Triggers>
                                                            <DataTrigger Binding="{Binding Type}" Value="red">
                                                                <Setter Property="Background" Value="red"/>
                                                            </DataTrigger>
                                                            <DataTrigger Binding="{Binding Type}" Value="green">
                                                                <Setter Property="Background" Value="Green"/>
                                                            </DataTrigger>
                                                        </Style.Triggers>
                                                    </Style>
                                                </Border.Style>
                                                <TextBlock Text="{Binding Eserc, StringFormat='{}{0} '}"></TextBlock>
                                            </Border>
                                        </DataTemplate>
                                    </ItemsControl.ItemTemplate>
                                </ItemsControl>
                            </DataTemplate>
                        </GridViewColumn.CellTemplate>
                    </GridViewColumn>
                    <GridViewColumn Header="Frequence" 
                                    DisplayMemberBinding="{Binding Freq}"/>
                </GridView>
            </ListView.View>
        </ListView>
