        <Style x:Key="radioListBox" TargetType="ListBox" BasedOn="{StaticResource {x:Type ListBox}}">
        <Setter Property="BorderThickness" Value="0" />
        <Setter Property="Margin" Value="5" />
        <Setter Property="Background" Value="{x:Null}" />
        <Setter Property="ItemContainerStyle">
            <Setter.Value>
                <Style TargetType="ListBoxItem" BasedOn="{StaticResource {x:Type ListBoxItem}}">
                    <Setter Property="Template">
                        <Setter.Value>
                            <ControlTemplate TargetType="ListBoxItem">
                                <Grid Background="Transparent">
                                    <RadioButton Focusable="False" IsHitTestVisible="False" IsChecked="{TemplateBinding IsSelected}" Content="{Binding MyName}"/>
                                </Grid>
                            </ControlTemplate>
                        </Setter.Value>
                    </Setter>
                    <Setter Property="ToolTip" Value="{Binding MyToolTip}" />
                </Style>
            </Setter.Value>
        </Setter>
    </Style>
