        <Label>
            <Label.Style>
                <Style TargetType="Label">
                    <Style.Triggers>
                        <DataTrigger Binding="{Binding YourEnum}" Value="something">
                            <Setter Property="Template">
                                <Setter.Value>
                                    <ControlTemplate>
                                        <TextBlock>
                                            Please wait
                                        </TextBlock>
                                    </ControlTemplate>
                                </Setter.Value>
                            </Setter>
                        </DataTrigger>
                        <DataTrigger Binding="{Binding YourEnum}" Value="somethingElse">
                            <Setter Property="Template">
                                <Setter.Value>
                                    <ControlTemplate>
                                        <TextBlock>
                                            Searching for item. <Hyperlink Command="{Binding DetailsCommand}">Link to details</Hyperlink>
                                        </TextBlock>
                                    </ControlTemplate>
                                </Setter.Value>
                            </Setter>
                        </DataTrigger>
                        <DataTrigger Binding="{Binding YourEnum}" Value="else">
                            <Setter Property="Template">
                                <Setter.Value>
                                    <ControlTemplate>
                                        <TextBlock>
                                            The content has been uploaded<LineBreak />
                                            The item is not ready to use
                                        </TextBlock>
                                    </ControlTemplate>
                                </Setter.Value>
                            </Setter>
                        </DataTrigger>
                    </Style.Triggers>
                </Style>
            </Label.Style>
        </Label>
