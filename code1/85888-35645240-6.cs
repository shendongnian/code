    <ResourceDictionary ...>
        <Style x:Key="ErrorControlStyle" TargetType="Control">
            <Style.Triggers>
                <MultiTrigger>
                    <MultiTrigger.Conditions>
                        <Condition Property="Validation.HasError" Value="True" />
                        <Condition Property="IsVisible" Value="True" />
                    </MultiTrigger.Conditions>
                    <Setter Property="Validation.ErrorTemplate" Value="{DynamicResource ValidationErrorTemplate}"/>
                </MultiTrigger>
            </Style.Triggers>
        </Style>
        
        <Style TargetType="PasswordBox" BasedOn="{extensions:MultiStyle . ErrorControlStyle}"/>
        <Style TargetType="TextBox" BasedOn="{extensions:MultiStyle . ErrorControlStyle}"/>
    </ResourceDictionary>
