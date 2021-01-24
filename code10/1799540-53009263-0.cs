    <Grid>
        <Button Width="100" Click="Button_Click" RenderTransformOrigin="0.5,0.5" Height="100">
            <Button.RenderTransform>
                    <ScaleTransform x:Name="AnimatedScaleTransform" ScaleX="-1" />
                </Button.RenderTransform>
            <Button.Template>
                <ControlTemplate>
                    <Image Source="gurbe1.jpg"/>
                </ControlTemplate>
            </Button.Template>
            <Button.Triggers>
                <EventTrigger RoutedEvent="Button.Click">
                    <BeginStoryboard>
                        <Storyboard>
                            <DoubleAnimation To="0" Duration="0:0:1"  Storyboard.TargetName="AnimatedScaleTransform" Storyboard.TargetProperty="(ScaleTransform.ScaleX)"/>
                        </Storyboard>
                    </BeginStoryboard>
                </EventTrigger>
            </Button.Triggers>
        </Button>
        <Button Width="100" Click="Button_Click" RenderTransformOrigin="0.5,0.5" Height="100">
            <Button.RenderTransform>
                <ScaleTransform x:Name="AnimatedScaleTransform2" ScaleX="0" />
            </Button.RenderTransform>
            <Button.Template>
                <ControlTemplate>
                    <Image Source="gurbe2.jpg"/>
                </ControlTemplate>
            </Button.Template>
            <Button.Triggers>
                <EventTrigger RoutedEvent="Loaded">
                    <BeginStoryboard>
                        <Storyboard>
                            <DoubleAnimation From="0" To="1" BeginTime="0:0:2.3" Duration="0:0:1" Storyboard.TargetName="AnimatedScaleTransform2" Storyboard.TargetProperty="(ScaleTransform.ScaleX)"/>
                        </Storyboard>
                    </BeginStoryboard>
                </EventTrigger>
            </Button.Triggers>
        </Button>
    </Grid>
