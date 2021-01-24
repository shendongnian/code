    <Window.Resources>
        <converters:ShortenFilePathConverter x:Key="ShortenFilePathConverter" />
    </Window.Resources>
...
    <ComboBox SelectedItem="{Binding LocalFolderSelection}" 
            ItemsSource="{Binding LocalFolders}">
        <ComboBox.ItemTemplate>
            <DataTemplate>
                <Label Content="{Binding Converter={StaticResource ShortenFilePathConverter}}"/>
            </DataTemplate>
        </ComboBox.ItemTemplate>
        <ComboBox.ItemContainerStyle>
            <Style TargetType="{x:Type ComboBoxItem}">
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="{x:Type ComboBoxItem}">
                            <Border x:Name="Bd"
                                    BorderBrush="{TemplateBinding BorderBrush}"
                                    BorderThickness="{TemplateBinding BorderThickness}"
                                    Background="{TemplateBinding Background}">
                                <StackPanel Orientation="Horizontal">
                                    <ContentPresenter HorizontalAlignment="{TemplateBinding HorizontalContentAlignment}" 
                                    VerticalAlignment="{TemplateBinding VerticalContentAlignment}">
                                        <ContentPresenter.Content>
                                            <Label Content="{Binding}"/>
                                        </ContentPresenter.Content>
                                    </ContentPresenter>
                                </StackPanel>
                            </Border>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
        </ComboBox.ItemContainerStyle>
    </ComboBox>
