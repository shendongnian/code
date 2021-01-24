        <ComboBox x:Name="comboBox" 
                  SelectedItem="{Binding SelectedItemInFilter, UpdateSourceTrigger=PropertyChanged}">
            <ComboBoxItem IsSelected="True">No Selection</ComboBoxItem>
            <ComboBoxItem>Car</ComboBoxItem>
            <ComboBoxItem>Truck</ComboBoxItem>
            <i:Interaction.Triggers>
                <i:EventTrigger EventName="SelectionChanged">
                    <i:InvokeCommandAction Command="{Binding SelectionChangedCommand}" CommandParameter="{Binding ElementName=comboBox, Path=SelectedItem}" />
                </i:EventTrigger>
            </i:Interaction.Triggers>
        </ComboBox>
