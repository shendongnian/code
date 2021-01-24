    <ContentControl>
        <ContentControl.Content>
            <TextBlock Text="Hello" />
        </ContentControl.Content>
        <ContentControl.Template>
            <ControlTemplate TargetType="ContentControl"> <!-- here -->
                <Border Background="Red">
                    <ContentPresenter />
                </Border>
            </ControlTemplate>
        </ContentControl.Template>
    </ContentControl>
