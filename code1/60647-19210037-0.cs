    <ComboBox Name="MyComboBox">
      <ComboBox.IsEnabled>
        <MultiBinding Converter="{StaticResource booleanAndConverter}">
          <Binding ElementName="SomeCheckBox" Path="IsChecked" />
          <Binding ElementName="AnotherCheckbox" Path="IsChecked"  />
        </MultiBinding>
      </ComboBox.IsEnabled>
    </ComboBox>
