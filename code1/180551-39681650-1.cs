    <DataGrid.Resources>
    
        <Style TargetType="DataGridCell" BasedOn="{StaticResource {x:Type DataGridCell}}">
            <Style.Triggers>
                    <MultiTrigger>
                        <MultiTrigger.Conditions>
                            <Condition Property="IsMouseOver"
                                       Value="True" />
                            <Condition Property="IsReadOnly"
                                       Value="False" />
                        </MultiTrigger.Conditions>
                        <MultiTrigger.Setters>
                            <Setter Property="IsEditing"
                                    Value="True" />
                        </MultiTrigger.Setters>
                    </MultiTrigger>
            </Style.Triggers>
        </Style>
    
    </DataGrid.Resources>
