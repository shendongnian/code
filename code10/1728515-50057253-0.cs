        <ToggleButton Width="75" Height="75" >
        <ToggleButton.Template>
            <ControlTemplate TargetType="ToggleButton">
                <Border Name="PART_Border">
                    <Image Name="PART_Image"  ></Image>
                </Border>
                <ControlTemplate.Triggers>
                    <Trigger Property="IsChecked" Value="True">
                        <Setter TargetName="PART_Image" Property="Source">
                            <Setter.Value>
                                <BitmapImage  UriSource="/images/first.PNG" />
                            </Setter.Value>
                        </Setter>
                    </Trigger>
                    <Trigger Property="IsChecked" Value="False">
                        <Setter TargetName="PART_Image" Property="Source">
                            <Setter.Value>
                                <BitmapImage UriSource="/images/second.PNG" />
                            </Setter.Value>
                        </Setter>
                    </Trigger>
                </ControlTemplate.Triggers>
            </ControlTemplate>
        </ToggleButton.Template>
    </ToggleButton>
