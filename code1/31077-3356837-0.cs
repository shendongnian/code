    <Button Height="30" Width="30">
        <Button.Style>
            <Style TargetType="{x:Type Button}">
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate>
                            <Path Name="HalfEllipse" Stroke="Black" StrokeThickness="1" Fill="Blue">
                                <Path.Data>
                                    <PathGeometry>
                                        <PathFigure IsFilled="True" StartPoint="0,0">
                                            <PolyBezierSegment Points="5,30 25,30 30,0" />
                                        </PathFigure>
                                    </PathGeometry>
                                </Path.Data>
                            </Path>
                            <ControlTemplate.Triggers>
                                <Trigger Property="IsMouseOver" Value="True">
                                    <Setter TargetName="HalfEllipse" Property="Fill">
                                        <Setter.Value>
                                            <SolidColorBrush Color="Green"/>
                                        </Setter.Value>
                                    </Setter>
                                </Trigger>
                            </ControlTemplate.Triggers>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
        </Button.Style>
    </Button>
