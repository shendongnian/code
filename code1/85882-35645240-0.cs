    <Style TargetType="TextBox" BasedOn="{StaticResource {x:Type TextBox}}">
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
    
    <Style TargetType="PasswordBox" BasedOn="{StaticResource {x:Type PasswordBox}}">
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
