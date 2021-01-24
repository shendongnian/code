    <Style TargetType="{x:Type Button}">
                <Setter Property="RenderTransformOrigin" Value="0.5 0.5" />
                <Setter Property="RenderTransform">
                    <Setter.Value>
                        <RotateTransform />
                    </Setter.Value>
                </Setter>
                <Style.Triggers>
                    <MultiDataTrigger>
                        <MultiDataTrigger.Conditions>
                            <Condition Binding="{Binding ElementName=btn , Path=IsPressed}" Value="True" />
                            <Condition Binding="{Binding ElementName=chk , Path=IsChecked}" Value="True" />
                        </MultiDataTrigger.Conditions>
                        <MultiDataTrigger.EnterActions>
                            <BeginStoryboard>
                                <Storyboard TargetProperty="RenderTransform.Angle">
                                    <DoubleAnimation From="0"
                            To="5"
                            Duration="0:0:0.05"
                            AutoReverse="True"
                            FillBehavior="Stop" />
                                    <DoubleAnimation BeginTime="0:0:0.05"
                            From="5"
                            To="-5"
                            Duration="0:0:0.1"
                            AutoReverse="True"
                            FillBehavior="Stop" />
                                    <DoubleAnimation BeginTime="0:0:0.2"
                            From="-5"
                            To="0"
                            Duration="0:0:0.1"
                            AutoReverse="False"
                            FillBehavior="Stop" />
                                </Storyboard>
                            </BeginStoryboard>
                        </MultiDataTrigger.EnterActions>
                    </MultiDataTrigger>
                </Style.Triggers>
            </Style>
