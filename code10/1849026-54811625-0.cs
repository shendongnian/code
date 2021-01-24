    <Border BorderThickness="1">
        <ComboBox x:Name="cbServer" ItemsSource="{Binding ServerCollection}"
                      SelectedItem="{Binding Server, Mode=TwoWay}">
            <ComboBox.Resources>
                <SolidColorBrush x:Key="{x:Static SystemColors.WindowFrameBrushKey}" Color="Red"/>
            </ComboBox.Resources>
            <i:Interaction.Triggers>
                <i:EventTrigger EventName="Loaded">
                    <i:InvokeCommandAction Command="{Binding Path=LoadServerListCommand}" />
                </i:EventTrigger>
            </i:Interaction.Triggers>
            <ComboBox.Style>
                <Style TargetType="ComboBox">
                    <Setter Property="ToolTip" Value="{Binding Error}" />
                    <Style.Triggers>
                        <DataTrigger Binding="{Binding Error.Length, FallbackValue=0}" Value="0">
                            <Setter Property="ToolTip" Value="{x:Null}" />
                        </DataTrigger>
                    </Style.Triggers>
                </Style>
            </ComboBox.Style>
        </ComboBox>
        <Border.Style>
            <Style TargetType="Border">
                <Setter Property="BorderBrush" Value="Red" />
                <Style.Triggers>
                    <DataTrigger Binding="{Binding Error.Length, FallbackValue=0}" Value="0">
                        <Setter Property="BorderBrush" Value="{x:Null}" />
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </Border.Style>
    </Border>
