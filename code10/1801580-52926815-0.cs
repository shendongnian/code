    <UserControl>
        <UserControl.Style>
            <Style TargetType="UserControl">
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="UserControl">
                            <Button Content="Button" />
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
                <Style.Triggers>
                    <DataTrigger Binding="{Binding ViewModelProperty}" Value="True">
                        <Setter Property="Template">
                            <Setter.Value>
                                <ControlTemplate TargetType="UserControl">
                                    <RadioButton Content="RadioButton" />
                                </ControlTemplate>
                            </Setter.Value>
                        </Setter>
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </UserControl.Style>
    </UserControl>
