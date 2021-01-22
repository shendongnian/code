            <Menu>
                <MenuItem ItemsSource="{Binding Path=ChildMenuItems}" Header="{Binding Path=Header}">
                    <MenuItem.Resources>
                        <HierarchicalDataTemplate DataType="{x:Type vm:MenuItemViewModel}" ItemsSource="{Binding ChildMenuItems}">
                            <MenuItem Header="{Binding Path=Header}" Command="{Binding Path=Command}"/>
                        </HierarchicalDataTemplate>
                        <DataTemplate DataType="{x:Type vm:SeparatorViewModel}">
                            <Separator>
                                <Separator.Template>
                                    <ControlTemplate>
                                        <Line X1="0" X2="1" Stroke="Black" StrokeThickness="1" Stretch="Fill"/>
                                    </ControlTemplate>
                                </Separator.Template>
                            </Separator>
                        </DataTemplate>
                    </MenuItem.Resources>
                </MenuItem>
            </Menu>
