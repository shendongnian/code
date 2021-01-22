      <Button>
            <Button.Style>
                <Style TargetType="{x:Type Button}">
                    <Setter Property="Content"
                            Value="No mouse over" />
                    <Style.Triggers>
                        <Trigger Property="IsMouseOver"
                                 Value="True">
                            <Setter Property="Content">
                                <Setter.Value>
                                    <CheckBox Content="Mouse is over" />
                                </Setter.Value>
                            </Setter>
                        </Trigger>
                    </Style.Triggers>
                </Style>
            </Button.Style>
        </Button>
