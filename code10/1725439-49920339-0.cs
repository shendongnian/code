    <ComboBox SelectedValuePath="Key" DisplayMemberPath="Value.ModuleName" 
        controls:TextBoxHelper.Watermark="All" Height="2"ItemsSource="{Binding Modules}">
                <ComboBox.ItemContainerStyle>
                    <Style TargetType="ComboBoxItem">
                        <Style.Triggers>
                            <DataTrigger Binding="{Binding Path=IsWarning }" Value="True">
                                <Setter Property="Backgroupd" Value="Blue" />
                            </DataTrigger>
                        </Style.Triggers>
                    </Style>
                </ComboBox.ItemContainerStyle>
            </ComboBox>
