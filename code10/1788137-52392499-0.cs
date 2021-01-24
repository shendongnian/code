    <DataTrigger Binding="{Binding HasValueChanged}" Value="True">
        <DataTrigger.EnterActions>
            <BeginStoryboard>
                <Storyboard>
                    <ColorAnimation Storyboard.TargetProperty="Background.Color"
                                    To="Red" Duration="0"/>
                </Storyboard>
            </BeginStoryboard>
        </DataTrigger.EnterActions>
        <DataTrigger.ExitActions>
            <BeginStoryboard>
                <Storyboard>
                    <ColorAnimation Storyboard.TargetProperty="Background.Color"
                                    From="Red" Duration="0:0:1"/>
                </Storyboard>
            </BeginStoryboard>
        </DataTrigger.ExitActions>
    </DataTrigger>
