    <ComboBox ... 
              SelectedValue="{Binding NameID}">
        <ComboBox.Resources>
            <local:MultiConverter x:Key="MultiConverter" />
        </ComboBox.Resources>
        <ComboBox.Style>
            <Style TargetType="ComboBox" BasedOn="{StaticResource ComboBoxFlat}">
                <Style.Triggers>
                    <DataTrigger Value="True">
                        <DataTrigger.Binding>
                            <MultiBinding Converter="{StaticResource MultiConverter}">
                                <Binding Path="SelectedIndex" RelativeSource="{RelativeSource Self}" />
                                <Binding Path="NameID" />
                            </MultiBinding>
                        </DataTrigger.Binding>
                        <Setter Property="BorderBrush" Value="Red" />
                        <Setter Property="BorderThickness" Value="10" />
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </ComboBox.Style>
    </ComboBox>
