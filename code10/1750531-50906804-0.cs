    <Style>
            <Setter Property="Control.Visibility" Value="Visible" />
            <Style.Triggers>
                <MultiDataTrigger>
                    <MultiDataTrigger.Conditions>
                        <Condition Binding="{Binding Path=IsPropA}" Value="false" />
                        <Condition Binding="{Binding Source={StaticResource ClassName},Path=PropertyName}" Value="False"/>                                    
                    </MultiDataTrigger.Conditions>
                    <Setter Property="Control.Visibility" Value="Hidden" />
                </MultiDataTrigger>
            </Style.Triggers>
        </Style>
