    <TextBox Validation.ErrorTemplate="{x:Null}">
        <TextBox.Text>
            <Binding Path="ValueB" UpdateSourceTrigger="PropertyChanged">
                <Binding.ValidationRules>
                    <local:DoubleValidation/>
                </Binding.ValidationRules>
            </Binding>
        </TextBox.Text>
        <TextBox.Style>
            <Style BasedOn="{StaticResource TextBoxB}" TargetType="TextBox">
                  <Style.Triggers>
                    <Trigger Property="Validation.HasError" Value="True">
                        <Setter Property="Background" Value="Red"/>
                    </Trigger>
                </Style.Triggers>
            </Style>
        </TextBox.Style>
    </TextBox>
