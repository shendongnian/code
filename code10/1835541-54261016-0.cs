    <Frame Loaded="FrameworkElement_OnLoaded" KeyUp="UIElement_OnKeyUp">
        <Frame.Content>
            <Page>
                <Label Content="Hello"></Label>
            </Page>
        </Frame.Content>
    </Frame>
    private void FrameworkElement_OnLoaded(object sender, RoutedEventArgs e)
    {
        ((Frame)sender).Focus();
    }
    private void UIElement_OnKeyUp(object sender, KeyEventArgs e)
    {
        MessageBox.Show("Key pressed");
    }
