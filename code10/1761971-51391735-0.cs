    <FrameworkElement.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <ResourceDictionary Source="Assets/PlusMinusExpanderStyles.xaml" />
            </ResourceDictionary.MergedDictionaries>
            <Style x:Key="CurrencyCellStyle" TargetType="{x:Type DataGridCell}">
                <Setter Property="Foreground" Value="#dddddd" />
                <Style.Triggers>
                    <Trigger Property="IsSelected" Value="True">
                        <Setter Property="Background" Value="Transparent"/>
                        <Setter Property="BorderBrush" Value="Transparent"/>
                    </Trigger>
                </Style.Triggers>
            </Style>
        </ResourceDictionary>
    </FrameworkElement.Resources>
