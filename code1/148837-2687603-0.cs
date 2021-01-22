    <Style x:Key="MouseOverButtonStyle" TargetType="Button">
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="Button">
                    <ControlTemplate.Resources>
                        <Style x:Key="ShadowStyle">
                            <Setter Property="Control.Foreground" Value="LightGray" />
                        </Style>
                    </ControlTemplate.Resources>
                    <Border Name="border" BorderThickness="1" Padding="4,2" BorderBrush="DarkGray" CornerRadius="3" Background="{TemplateBinding Background}">
                        <Grid >
                            <ContentPresenter HorizontalAlignment="Center" VerticalAlignment="Center" Name="contentShadow" Style="{StaticResource ShadowStyle}">
                                <ContentPresenter.RenderTransform>
                                    <TranslateTransform X="1.0" Y="1.0" />
                                </ContentPresenter.RenderTransform>
                            </ContentPresenter>
                            <ContentPresenter HorizontalAlignment="Center" VerticalAlignment="Center" Name="content"/>
                        </Grid>
                    </Border>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
        <Style.Triggers>
            <Trigger Property="IsMouseOver" Value="True">
                <Setter Property="Background" Value="Beige" />
            </Trigger>
        </Style.Triggers>
    </Style>
