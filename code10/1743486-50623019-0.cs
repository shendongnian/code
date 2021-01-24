    <TextBlock x:Name="LinkToQuery" Grid.Row="39" Grid.Column="1" Grid.ColumnSpan="4" Margin="10">           
        <Hyperlink x:Name="URLQuery" RequestNavigate="Hyperlink_RequestNavigate" Foreground="Blue">
            <Run x:Name="linkText" Text="Selected: A" />
        </Hyperlink>
    </TextBlock>
----------
    private void component_ComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
    {
        string selectedComponent = box_ComboBox.SelectedItem.ToString();
        linkText.Text = string.Format("Selected: {0} ", selectedComponent);
        URLQuery.NavigateUri = new System.Uri(LinkQuery[selectedComponent], System.UriKind.Absolute);
    }
