    <GridViewColumn Header="Permission" Width="170" >
                        <GridViewColumn.CellTemplate>
                            <DataTemplate>
                                <TextBlock Text="{Binding Permission}">
                                    <TextBlock.Style>
                                        <Style TargetType="{x:Type TextBlock}">
                                            <Style.Triggers>
                                                <DataTrigger Binding="{Binding Path=permission, Converter={StaticResource PassConverter}}">
                                                    <DataTrigger.Value>True</DataTrigger.Value>
                                                    <Setter Property="Foreground" Value="#4c72cc"/>
                                                </DataTrigger>
                                                <DataTrigger Binding="{Binding permission,Converter={StaticResource FailConverter}}" >
                                                    <DataTrigger.Value>True</DataTrigger.Value>
                                                    <Setter Property="Foreground" Value="#ef6eab"/>
                                                </DataTrigger>
                                            </Style.Triggers>
                                        </Style>
                                    </TextBlock.Style>
                                </TextBlock>
                            </DataTemplate>
                        </GridViewColumn.CellTemplate>
                    </GridViewColumn>
