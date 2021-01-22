    <Grid>
        <i:Interaction.Triggers>
            <i:EventTrigger EventName="MouseEnter">
                <si:InvokeDataCommand Command="{Binding DoSomethingCommand}"/>
            </i:EventTrigger>
        </i:Interaction.Triggers>
        ...
    </Grid>
