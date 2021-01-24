    <ComboBox>
        <ComboBox.ItemsSource>
            <CompositeCollection>
                <ComboBoxItem Content="--All--" />
                <CollectionContainer Collection="{Binding Source=ResultObjects}" />
                <ComboBoxItem Content="--Custom--" />
            </CompositeCollection>
        </ComboBox.ItemsSource>
    </ComboBox>
