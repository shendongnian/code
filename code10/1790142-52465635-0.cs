                    <Label>
                        <Label.Style>
                            <Style TargetType="{x:Type Label}">
                                <Setter Property="Content" Value="{Binding MyDate, StringFormat=T}"/>
                                <Style.Triggers>
                                    <MultiDataTrigger>
                                        <MultiDataTrigger.Conditions>
                                            <Condition Binding="{Binding MyDate.Hour}" Value="0" />
                                            <Condition Binding="{Binding MyDate.Minute}" Value="0" />
                                            <Condition Binding="{Binding MyDate.Second}" Value="0" />
                                        </MultiDataTrigger.Conditions>
                                        <Setter Property="Content" Value=""/>
                                    </MultiDataTrigger>
                                </Style.Triggers>
                            </Style>
                        </Label.Style>
                    </Label>
