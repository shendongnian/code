    <DataTemplate DataType="{x:Type local:DocumentPart}">
        <Border BorderBrush="Black" BorderThickness="1" Padding="0" CornerRadius="5" Background="White">
            <Border.InputBindings>
                <MouseBinding MouseAction="LeftDoubleClick"
                              Command="{Binding YourBindableCommand}"
            </Border.InputBindings>
            <Border.Style>
                <Style>
                    <Style.Triggers>
                        <Trigger Property="Border.IsMouseOver" Value="True">
                            <Setter Property="Border.Effect">
                                <Setter.Value>
                                    <DropShadowEffect BlurRadius="2" Color="#BBBBBB" 
                                                    Opacity="0.3" Direction="315"/>
                                </Setter.Value>
                            </Setter>
                        </Trigger>
                    </Style.Triggers>
                </Style>
            </Border.Style>
            <StackPanel Orientation="Horizontal">
                <StackPanel Orientation="Vertical" Margin="2">
                    <TextBlock Text="{Binding Name}"/>
                </StackPanel>
            </StackPanel>
        </Border>
    </DataTemplate>
