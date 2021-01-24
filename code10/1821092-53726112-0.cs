    <ComboBox x:Name="cmb" xmlns:s="clr-namespace:System;assembly=mscorlib">
        <s:Int32>1</s:Int32>
        <s:Int32>2</s:Int32>
        <s:Int32>3</s:Int32>
        <s:Int32>4</s:Int32>
    </ComboBox>
    <GroupBox Header="...">
        <GroupBox.Style>
            <Style TargetType="GroupBox">
                <Style.Triggers>
                    <DataTrigger Binding="{Binding SelectedItem, ElementName=cmb}" Value="1">
                        <Setter Property="Content">
                            <Setter.Value>
                                <TextBlock Text="1..." />
                            </Setter.Value>
                        </Setter>
                    </DataTrigger>
                    <DataTrigger Binding="{Binding SelectedItem, ElementName=cmb}" Value="2">
                        <Setter Property="Content">
                            <Setter.Value>
                                <Button Content="2..." />
                            </Setter.Value>
                        </Setter>
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </GroupBox.Style>
    </GroupBox>
