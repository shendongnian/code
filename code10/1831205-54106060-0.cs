        <ToggleButton>
            <ToggleButton.Style>
                <Style TargetType="ToggleButton">
                    <Setter Property="Template">
                        <Setter.Value>
                            <ControlTemplate TargetType="ToggleButton">
                                <Image x:Name="borderImage" Source="Image1.jpg"/>
                                <ControlTemplate.Triggers>
                                    <Trigger Property="IsChecked" Value="true">
                                        <Setter Property="Source" Value="Image2.jpg" TargetName="borderImage"/>
                                    </Trigger>
                                </ControlTemplate.Triggers>
                            </ControlTemplate>
                        </Setter.Value>
                    </Setter>
                </Style>
            </ToggleButton.Style>
        </ToggleButton>
