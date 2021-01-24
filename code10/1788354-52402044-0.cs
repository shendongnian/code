    <xctk:ColorPicker x:Name="canvas_Copy" ColorMode="ColorCanvas" VerticalAlignment="Top" Margin="93,323,409,0" >
        <xctk:ColorPicker.Resources>
            <BooleanToVisibilityConverter x:Key="BooleanToVisibilityConverter" />
        </xctk:ColorPicker.Resources>
        <xctk:ColorPicker.ButtonStyle>
            <Style TargetType="ToggleButton">
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="ToggleButton" xmlns:chrome="clr-namespace:Xceed.Wpf.Toolkit.Chromes;assembly=Xceed.Wpf.Toolkit">
                            <Grid SnapsToDevicePixels="True">
                                <Grid>
                                    <Grid.ColumnDefinitions>
                                        <ColumnDefinition Width="*" />
                                        <ColumnDefinition Width="Auto" />
                                    </Grid.ColumnDefinitions>
                                    <Border Background="{TemplateBinding Background}"
                                            BorderBrush="{TemplateBinding BorderBrush}"
                                            BorderThickness="{TemplateBinding BorderThickness}"
                                            Padding="{TemplateBinding Padding}"
                                            SnapsToDevicePixels="True">
                                        <ContentPresenter Content="{TemplateBinding Content}"
                                                        ContentTemplate="{TemplateBinding ContentTemplate}"
                                                        ContentTemplateSelector="{TemplateBinding ContentTemplateSelector}"
                                                        VerticalAlignment="{TemplateBinding VerticalContentAlignment}"
                                                        HorizontalAlignment="{TemplateBinding HorizontalContentAlignment}" />
                                    </Border>
                                    <chrome:ButtonChrome x:Name="ToggleButtonChrome"
                                                        Grid.Column="1"
                                                        CornerRadius="0,2.75,2.75,0"
                                                        Visibility="{Binding ShowDropDownButton, RelativeSource={RelativeSource Mode=FindAncestor, AncestorType=xctk:ColorPicker}, Converter={StaticResource BooleanToVisibilityConverter}}"
                                                        RenderChecked="{Binding IsOpen, RelativeSource={RelativeSource Mode=FindAncestor, AncestorType=xctk:ColorPicker}}"
                                                        RenderEnabled="{Binding IsEnabled, RelativeSource={RelativeSource Mode=FindAncestor, AncestorType=xctk:ColorPicker}}"
                                                        RenderMouseOver="{TemplateBinding IsMouseOver}"
                                                        RenderPressed="{TemplateBinding IsPressed}">
                                    </chrome:ButtonChrome>
                                </Grid>
                            </Grid>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
        </xctk:ColorPicker.ButtonStyle>
    </xctk:ColorPicker>
