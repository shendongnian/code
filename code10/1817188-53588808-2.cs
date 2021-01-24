    <local:MultiplyColorConverter x:Key="MultiplyColorConverter"/>
        <Style TargetType="{x:Type TreeViewItem}">
            <Setter Property="Template">
                <Setter.Value>
                <ControlTemplate TargetType="TreeViewItem">
                    <Border x:Name="Bd">
                        <Border.Background>
                            <MultiBinding Mode="OneWay" Converter="{StaticResource MultiplyColorConverter}">
                                <Binding Path="BaseColor" Mode="OneWay"/>
                                <Binding RelativeSource="{RelativeSource Self}" Path="(local:ColorTransform.Factor)" Mode="OneWay"/>
                            </MultiBinding>
                        </Border.Background>
                        <TextBlock x:Name="Text" Text="{Binding}"/>
                    </Border>
                    <ControlTemplate.Triggers>
                        <Trigger Property="IsMouseOver" Value="True">
                            <Setter TargetName="Bd" Property="local:ColorTransform.Factor" Value="0.5"/>
                        </Trigger>
                        <Trigger Property="IsFocused" Value="True">
                            <Setter TargetName="Bd" Property="local:ColorTransform.Factor" Value="0.5"/>
                        </Trigger>
                        <Trigger Property="IsSelected" Value="True">
                            <Setter TargetName="Bd" Property="local:ColorTransform.Factor" Value="0.3"/>
                        </Trigger>
                    </ControlTemplate.Triggers>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>
