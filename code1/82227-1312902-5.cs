    <Menu>
        <MenuItem Header="Enemies" ItemsSource="{Binding AvailableEnemyClasses}">
            <MenuItem.ItemContainerStyle>
                <Style TargetType="MenuItem">
                    <Setter Property="Header" Value="{Binding}"/>
                    <Setter Property="IsChecked">
                        <Setter.Value>
                            <MultiBinding Converter="{StaticResource YourConverter}">
                                <Binding .../>
                                <Binding .../>
                            </MultiBinding>
                        </Setter.Value>
                    </Setter>
                </Style>
            </MenuItem.ItemContainerStyle>
        </MenuItem>
    </Menu>
