    <Style TargetType="{x:Type DataGridCell}" BasedOn="{StaticResource DataGridCell}">
    <Setter Property="Background" Value="{StaticResource DataGridCellBackgroundBrush}"/>
    <Setter Property="BorderBrush" Value="{StaticResource DataGridBorderBrush}" />
    <Setter Property="BorderThickness" Value="0"/>
    
    <Style.Triggers>
        <!--  IsSelected  -->
        <Trigger Property="IsSelected" Value="True">
            <Setter Property="Foreground" Value="{StaticResource BlackBrush}" />
        </Trigger>
        <MultiTrigger>
            <MultiTrigger.Conditions>
                <Condition Property="Controls:DataGridCellHelper.IsCellOrRowHeader" Value="True" />
                <Condition Property="IsSelected" Value="True" />
            </MultiTrigger.Conditions>
            <Setter Property="Background" Value="{StaticResource DataGridCellBackgroundBrush}" />
            <Setter Property="BorderBrush" Value="{StaticResource DataGridCellBackgroundBrush}" />
        </MultiTrigger>
    //others properties 
