    <Setter Property="Validation.ErrorTemplate">
        <Setter.Value>
            <ControlTemplate>
                <ControlTemplate.Resources>
                    <BooleanToVisibilityConverter x:Key="converter" />
	        </ControlTemplate.Resources>
                <DockPanel LastChildFill="True">
                    <Border 
                        BorderThickness="1"
                        BorderBrush="Red"
                        Visibility="{Binding ElementName=placeholder, Mode=OneWay, Path=AdornedElement.IsVisible, Converter={StaticResource converter}}"
                        >
                        <AdornedElementPlaceholder x:Name="placeholder" />
                    </Border>
                 </DockPanel>
             </ControlTemplate>
        </Setter.Value>
    </Setter>
