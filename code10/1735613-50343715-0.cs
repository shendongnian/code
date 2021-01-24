     <TreeView.ItemContainerStyle>
                            <Style TargetType="TreeViewItem">
                                <EventSetter Event="MouseRightButtonDown" Handler="TreeSetup_MouseRightButtonDown"/>
                                <Setter Property="IsSelected" Value="{Binding Path=IsSelected, Mode=TwoWay}" />
                                <Setter Property="IsExpanded" Value="{Binding IsExpanded, Mode=TwoWay}"/>
                                <Style.Triggers>
                                    <Trigger Property="IsSelected" Value="True">
                                        <Setter Property="FontWeight" Value="Bold" />
                                    </Trigger>
                                </Style.Triggers>
                            </Style>
                        </TreeView.ItemContainerStyle>
