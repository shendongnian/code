    <Grid x:Name="BottomPanel" Background="Yellow" Height="0" Width="200">
        <Grid.Style>
            <Style TargetType="Grid">
                <Style.Triggers>
                    <DataTrigger Binding="{Binding IsBottomOpened}">
                        <DataTrigger.EnterActions>
                            <BeginStoryboard>
                                <Storyboard>
                                    <DoubleAnimation Storyboard.TargetProperty="Height"
                                             To="128"
                                             Duration="0:0:0.3" />
                                </Storyboard>
                            </BeginStoryboard>
                        </DataTrigger.EnterActions>
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </Grid.Style>
    </Grid>
