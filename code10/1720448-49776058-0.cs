    <Style TargetType="AutoSuggestBox">
        ...
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="AutoSuggestBox">
                    <Grid>
                        ...
                        <TextBox x:Name="TextBox" 
                                 ...
                                 />
                        <Popup x:Name="SuggestionsPopup">
                            <Border x:Name="SuggestionsContainer">
                                <Border.RenderTransform>
                                    <TranslateTransform x:Name="UpwardTransform" />
                                </Border.RenderTransform>
                                <ListView
                                    x:Name="SuggestionsList"
                                    ...
                                    >
                                    <ListView.ItemContainerTransitions>
                                        <TransitionCollection />
                                    </ListView.ItemContainerTransitions>
                                </ListView>
                            </Border>
                        </Popup>
                    </Grid>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>
