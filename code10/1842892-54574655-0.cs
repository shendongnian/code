    <Button Content="Outer button" Command="{Binding TestCmd}">
        <Button.Template>
            <ControlTemplate TargetType="ButtonBase">
                <Grid>
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition Width="AUTO" />
                        <ColumnDefinition Width="AUTO" />
                    </Grid.ColumnDefinitions>
                    <Label Grid.Column="0" Content="LABEL CONTENT" Foreground="BlueViolet"/>
                    <Button Grid.Column="1" Content="INNER BUTTON" Command="{Binding TestCmd2}"/>
                </Grid>
            </ControlTemplate>
        </Button.Template>
    </Button>
