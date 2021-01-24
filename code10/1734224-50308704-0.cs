    <Label Content="{Binding StatusText}">
            <Label.Style>
                <Style TargetType="Label">
                    <Style.Triggers>
                        <Trigger Property="Content" Value="Please reach out here. No access can be provided.">
                            <Setter Property="ContentTemplate">
                                <Setter.Value>
                                    <DataTemplate>
                                        <TextBlock>
                                            <Run Text="Please reach out "/>
                                            <Hyperlink NavigateUri="www.google.com">here</Hyperlink>
                                            <Run Text=" for access."/>
                                        </TextBlock>
                                    </DataTemplate>
                                </Setter.Value>
                            </Setter>
                        </Trigger>
                    </Style.Triggers>
                </Style>
            </Label.Style>
        </Label>
