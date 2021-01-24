    <Grid>
        <Grid.ColumnDefinitions>
            <ColumnDefinition />
            <ColumnDefinition />
        </Grid.ColumnDefinitions>
        <Grid.Resources>
            <Style TargetType="CheckBox">
                <Setter Property="Command" Value="{Binding SomeCommand}" />
            </Style>
        </Grid.Resources>
        <CheckBox>1</CheckBox>
        <CheckBox Grid.Column="1">2</CheckBox>
    </Grid>
