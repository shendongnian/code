    <ControlTemplate.Triggers>
        <MultiTrigger>
            <MultiTrigger.Conditions>
                <Condition Property="IsFocused" Value="false"/>
                <Condition Property="Text" Value="{x:Null}"/>
            </MultiTrigger.Conditions>
            <Setter TargetName="Watermark" Property="Visibility" Value="Visible"/>
        </MultiTrigger>
        <MultiTrigger>
            <MultiTrigger.Conditions>
                <Condition Property="IsFocused" Value="false"/>
                <Condition Property="Text" Value=""/>
            </MultiTrigger.Conditions>
            <Setter TargetName="Watermark" Property="Visibility" Value="Visible"/>
        </MultiTrigger>
    </ControlTemplate.Triggers>
