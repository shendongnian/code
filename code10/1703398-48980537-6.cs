    <GridViewColumn Header="Permission" Width="170" >
                        <GridViewColumn.CellTemplate>
                            <DataTemplate>
                                <TextBlock Text="{Binding Permission}">
                                    <TextBlock.Style>
                                        <Style TargetType="{x:Type TextBlock}">
                                            <Style.Triggers>
                                                <DataTrigger>
                                                    <DataTrigger.Binding>
                                                        <MultiBinding Converter="{StaticResource PassFailConverter}">
                                                            <Binding Path="permission"/>
                                                            <Binding>
                                                                <Binding.Source>
                                                                    <system:String>
                                                                        Pass
                                                                    </system:String>
                                                                </Binding.Source>
                                                            </Binding>
                                                        </MultiBinding>
                                                    </DataTrigger.Binding>
                                                    <DataTrigger.Value>True</DataTrigger.Value>
                                                    <Setter Property="Foreground" Value="#4c72cc"/>
                                                </DataTrigger>
                                                <DataTrigger>
                                                    <DataTrigger.Binding>
                                                        <MultiBinding Converter="{StaticResource PassFailConverter}">
                                                            <Binding Path="permission"/>
                                                            <Binding>
                                                                <Binding.Source>
                                                                    <system:String>
                                                                        Fail
                                                                    </system:String>
                                                                </Binding.Source>
                                                            </Binding>
                                                        </MultiBinding>
                                                    </DataTrigger.Binding>
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
