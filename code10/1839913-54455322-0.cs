    <Style TargetType="Grid">
        <Style.Triggers>
            <DataTrigger Binding="{Binding Open}" Value="True">
                <DataTrigger.EnterActions>
                    <BeginStoryboard>
                        <Storyboard>
                            <DoubleAnimation Duration="0:0:1" Storyboard.TargetProperty="Width" From="0" To="300" FillBehavior="Stop"/>
                        </Storyboard>
                    </BeginStoryboard>
                </DataTrigger.EnterActions>
            </DataTrigger>
            <DataTrigger Binding="{Binding Open}" Value="False">
                <DataTrigger.EnterActions>
                    <BeginStoryboard>
                        <Storyboard>
                            <DoubleAnimation Duration="0:0:1" Storyboard.TargetProperty="Width" From="300" To="0" FillBehavior="Stop"/>
                        </Storyboard>
                    </BeginStoryboard>
                </DataTrigger.EnterActions>
            </DataTrigger>
        </Style.Triggers>
    </Style>
