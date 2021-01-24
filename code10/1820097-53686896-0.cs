        <Rectangle Fill="Blue" Margin="5,0,0,0" Stroke="#181a1f" StrokeThickness="1">
            <Rectangle.InputBindings>
                <MouseBinding Gesture="LeftClick" Command="{Binding CommandSetColor}" CommandParameter="Blue" />
            </Rectangle.InputBindings>
            <Rectangle.Style>
                <Style>
                    <Setter Property="Rectangle.Width" Value="18" />
                    <Setter Property="Rectangle.Height" Value="18" />
                    <Style.Triggers>
                        <DataTrigger Binding="{Binding NewTaskColor}" Value="Blue">
                            <Setter Property="Rectangle.Width" Value="18" />
                            <Setter Property="Rectangle.Height" Value="18" />
                        </DataTrigger>
                        <DataTrigger Binding="{Binding NewTaskColor}" Value="None">
                            <Setter Property="Rectangle.Width" Value="16" />
                            <Setter Property="Rectangle.Height" Value="16" />
                        </DataTrigger>
                    </Style.Triggers>
                </Style>
            </Rectangle.Style>
        </Rectangle>
