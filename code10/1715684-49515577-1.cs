    <ComboBox IsSynchronizedWithCurrentItem="True">
        <ComboBox.SelectedItem>
            <Binding Path="SelectedModule" Mode="TwoWay">
                <Binding.Converter>
                    <local:Converter />
                </Binding.Converter>
            </Binding>
        </ComboBox.SelectedItem>
        <ComboBox.ItemsSource>
            <CompositeCollection>
                <ComboBoxItem IsEnabled="True" Content="All">
                    <ComboBoxItem.Tag>
                        <system:Int32>0</system:Int32>
                    </ComboBoxItem.Tag>
                </ComboBoxItem>
                <CollectionContainer Collection="{Binding Source={StaticResource ResourceKey=ModulesCombo}}" />
            </CompositeCollection>
        </ComboBox.ItemsSource>
    </ComboBox>
