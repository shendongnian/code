    <ComboBox Name="PradPojemnosciowyComboBox"
                 SelectedValue="{Binding SelectedItem, Mode=TwoWay,UpdateSourceTrigger=PropertyChanged}"
                 ItemsSource="{Binding Path=LiniaWyComboBox, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}"
                 IsEditable="True"
                 IsReadOnly="False"
                 Text="{Binding Prad_pojemnosciowy, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}"
                 IsTextSearchEnabled="False" 
                 IsSynchronizedWithCurrentItem="True"
                 PreviewKeyDown="PradPojemnosciowyComboBox_OnPreviewKeyDown">
        <ComboBox.Style>
            <Style TargetType="ComboBox">
                <Style.Triggers>
                    <Trigger Property="SelectedValue" Value="{x:Null}">
                        <Setter Property="SelectedIndex" Value="{Binding LiniaWyComboBox}"/>
                    </Trigger>
                </Style.Triggers>
            </Style>
        </ComboBox.Style>
        <ComboBox.ItemContainerStyle>
            <Style TargetType="ComboBoxItem">
                <Setter Property="ToolTip">
                    <Setter.Value>
                        <TextBlock Text="{Binding}" />
                    </Setter.Value>
                </Setter>
            </Style>
        </ComboBox.ItemContainerStyle>
    </ComboBox>
