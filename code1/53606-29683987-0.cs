                        <TextBox.Style>
                            <Style TargetType="TextBox">
                                <Style.Triggers>
                                    <MultiTrigger>
                                        <MultiTrigger.Conditions>
                                            <Condition Property="IsFocused" Value="True"/>
                                            <Condition Property="Text" Value=""/>
                                        </MultiTrigger.Conditions>
                                        <MultiTrigger.Setters>
                                            <Setter Property="Background">
                                                <Setter.Value>
                                                    <ImageBrush ImageSource="/Images/Scan.PNG" Stretch="Uniform" AlignmentX="Left"/>
                                                </Setter.Value>
                                            </Setter>
                                        </MultiTrigger.Setters>
                                    </MultiTrigger>
                                </Style.Triggers>
                            </Style>
                        </TextBox.Style>
                    </TextBox>
