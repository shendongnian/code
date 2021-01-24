    <ComboBox ItemSource="{Binding Items}">
        <ComboBox.Resources>
            <Style TargetType="ComboBoxItem">
                <Setter Property="Backgournd">
                    <Setter.Value>
                        <SolidColorBrush Color="{Binding RelativeSource=
                        {RelativeSource AncestorType=ComboBoxItem},
                        Path=Content.Color}"/>
                    </Setter.Value>
                </Setter>
                <Setter Property="Margin" Value="-1 -1"/>
            </Style>
        </ComboBox.Resources>
    </ComboBox>
