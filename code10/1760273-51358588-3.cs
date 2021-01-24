            // OK
            private void buttonOK_Click(object sender, RoutedEventArgs e)
            {
                try
                {
                    SetButtonCornerRadiusAndTriggerStyling(buttonOK, 5);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error at 'buttonOK_Click'" + Environment.NewLine + Environment.NewLine + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
    
            // Set Button Corner Radius and Trigger Styling
            public static void SetButtonCornerRadiusAndTriggerStyling(Button toStyle, int theCornerRadius,
                                                                      string theMouseOverBackground = "", string theMouseOverBorderBrush = "", string theMouseOverForeground = "",
                                                                      string thePressedBackground = "", string thePressedBorderBrush = "", string thePressedForeground = "",
                                                                      string theDisabledBackground = "", string theDisabledBorderBrush = "", string theDisabledForeground = "")
            {
                try
                {
                    // Corner Radius
                    int cornerRadius = theCornerRadius;
    
                    // Mouse Over
                    string defaultMouseOverBackground = "#BEE6FD";
                    string defaultMouseOverBorderBrush = "#3C7FB1";
                    string defaultMouseOverForeground = "Black";
    
                    string mouseOverBackground = theMouseOverBackground;
                    string mouseOverBorderBrush = theMouseOverBorderBrush;
                    string mouseOverForeground = theMouseOverForeground;
    
                    if (mouseOverBackground == null) { mouseOverBackground = ""; }
                    if (mouseOverBorderBrush == null) { mouseOverBorderBrush = ""; }
                    if (mouseOverForeground == null) { mouseOverForeground = ""; }
    
                    if (mouseOverBackground.Length == 0) { mouseOverBackground = defaultMouseOverBackground; }
                    if (mouseOverBorderBrush.Length == 0) { mouseOverBorderBrush = defaultMouseOverBorderBrush; }
                    if (mouseOverForeground.Length == 0) { mouseOverForeground = defaultMouseOverForeground; }
    
                    // Pressed
                    string defaultPressedBackground = "#C4E5F6";
                    string defaultPressedBorderBrush = "#2C628B";
                    string defaultPressedForeground = "Black";
    
                    string pressedBackground = thePressedBackground;
                    string pressedBorderBrush = thePressedBorderBrush;
                    string pressedForeground = thePressedForeground;
    
                    if (pressedBackground == null) { pressedBackground = ""; }
                    if (pressedBorderBrush == null) { pressedBorderBrush = ""; }
                    if (pressedForeground == null) { pressedForeground = ""; }
    
                    if (pressedBackground.Length == 0) { pressedBackground = defaultPressedBackground; }
                    if (pressedBorderBrush.Length == 0) { pressedBorderBrush = defaultPressedBorderBrush; }
                    if (pressedForeground.Length == 0) { pressedForeground = defaultPressedForeground; }
    
                    // Disabled
                    string defaultDisabledBackground = "#F4F4F4";
                    string defaultDisabledBorderBrush = "#ADB2B5";
                    string defaultDisabledForeground = "#83838C";
    
                    string disabledBackground = theDisabledBackground;
                    string disabledBorderBrush = theDisabledBorderBrush;
                    string disabledForeground = theDisabledForeground;
    
                    if (disabledBackground == null) { disabledBackground = ""; }
                    if (disabledBorderBrush == null) { disabledBorderBrush = ""; }
                    if (disabledForeground == null) { disabledForeground = ""; }
    
                    if (disabledBackground.Length == 0) { disabledBackground = defaultDisabledBackground; }
                    if (disabledBorderBrush.Length == 0) { disabledBorderBrush = defaultDisabledBorderBrush; }
                    if (disabledForeground.Length == 0) { disabledForeground = defaultDisabledForeground; }
    
                    string mainButtonStyleXAML = @"<Style xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation' xmlns:x='http://schemas.microsoft.com/winfx/2006/xaml' TargetType=""Button"">
    
        <Setter Property=""Template"">
            <Setter.Value>
                <ControlTemplate TargetType=""ButtonBase"">
                    <Border BorderThickness=""{TemplateBinding Border.BorderThickness}""
                            BorderBrush=""{TemplateBinding Border.BorderBrush}""
                            Background=""{TemplateBinding Panel.Background}""
                            Name=""BorderMain""
                            CornerRadius=""{CornerRadius}""
                            SnapsToDevicePixels=""True"">
    
                        <ContentPresenter RecognizesAccessKey=""True""
                                          Content=""{TemplateBinding ContentControl.Content}""
                                          ContentTemplate=""{TemplateBinding ContentControl.ContentTemplate}""
                                          ContentStringFormat=""{TemplateBinding ContentControl.ContentStringFormat}""
                                          Name=""ContentPresenterMain""
                                          Margin=""{TemplateBinding Control.Padding}""
                                          HorizontalAlignment=""{TemplateBinding Control.HorizontalContentAlignment}""
                                          VerticalAlignment=""{TemplateBinding Control.VerticalContentAlignment}""
                                          SnapsToDevicePixels=""{TemplateBinding UIElement.SnapsToDevicePixels}""
                                          Focusable=""False"" />
    
                    </Border>
    
                <ControlTemplate.Triggers>
    
                    <!-- Default -->
                    <Trigger Property=""Button.IsDefaulted"" Value=""True"">
                        <Setter Property=""Border.BorderBrush"" TargetName=""BorderMain"">
                            <Setter.Value>
                                <DynamicResource ResourceKey=""{x:Static SystemColors.HighlightBrushKey}"" />
                            </Setter.Value>
                        </Setter>
                    </Trigger>
    
                    <!-- Mouse Over -->
                    <Trigger Property=""UIElement.IsMouseOver"" Value=""True"">
                        <Setter Property=""Panel.Background"" TargetName=""BorderMain"">
                            <Setter.Value>
                                <SolidColorBrush>{MouseOverBackground}</SolidColorBrush>
                            </Setter.Value>
                        </Setter>
                        <Setter Property=""Border.BorderBrush"" TargetName=""BorderMain"">
                            <Setter.Value>
                                <SolidColorBrush>{MouseOverBorderBrush}</SolidColorBrush>
                            </Setter.Value>
                        </Setter>
                        <Setter Property=""TextElement.Foreground"" TargetName=""ContentPresenterMain"">
                            <Setter.Value>
                                <SolidColorBrush>{MouseOverForeground}</SolidColorBrush>
                            </Setter.Value>
                        </Setter>
                    </Trigger>
    
                    <!-- Pressed -->
                    <Trigger Property=""ButtonBase.IsPressed"" Value=""True"">
                        <Setter Property=""Panel.Background"" TargetName=""BorderMain"">
                            <Setter.Value>
                                <SolidColorBrush>{PressedBackground}</SolidColorBrush>
                            </Setter.Value>
                        </Setter>
                        <Setter Property=""Border.BorderBrush"" TargetName=""BorderMain"">
                            <Setter.Value>
                                <SolidColorBrush>{PressedBorderBrush}</SolidColorBrush>
                            </Setter.Value>
                        </Setter>
                        <Setter Property=""TextElement.Foreground"" TargetName=""ContentPresenterMain"">
                            <Setter.Value>
                                <SolidColorBrush>{PressedForeground}</SolidColorBrush>
                            </Setter.Value>
                        </Setter>
                    </Trigger>
    
                    <!-- Disabled -->
                    <Trigger Property=""UIElement.IsEnabled"" Value=""False"">
                        <Setter Property=""Panel.Background"" TargetName=""BorderMain"">
                            <Setter.Value>
                                <SolidColorBrush>{DisabledBackground}</SolidColorBrush>
                            </Setter.Value>
                        </Setter>
                        <Setter Property=""Border.BorderBrush"" TargetName=""BorderMain"">
                            <Setter.Value>
                                <SolidColorBrush>{DisabledBorderBrush}</SolidColorBrush>
                            </Setter.Value>
                        </Setter>
                        <Setter Property=""TextElement.Foreground"" TargetName=""ContentPresenterMain"">
                            <Setter.Value>
                                <SolidColorBrush>{DisabledForeground}</SolidColorBrush>
                            </Setter.Value>
                        </Setter>
                    </Trigger>
    
                </ControlTemplate.Triggers>
    
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    
    </Style>";
    
                    // Replace Values
                    mainButtonStyleXAML = mainButtonStyleXAML.Replace("{CornerRadius}", cornerRadius.ToString());
    
                    mainButtonStyleXAML = mainButtonStyleXAML.Replace("{MouseOverBackground}", mouseOverBackground);
                    mainButtonStyleXAML = mainButtonStyleXAML.Replace("{MouseOverBorderBrush}", mouseOverBorderBrush);
                    mainButtonStyleXAML = mainButtonStyleXAML.Replace("{MouseOverForeground}", mouseOverForeground);
    
                    mainButtonStyleXAML = mainButtonStyleXAML.Replace("{PressedBackground}", pressedBackground);
                    mainButtonStyleXAML = mainButtonStyleXAML.Replace("{PressedBorderBrush}", pressedBorderBrush);
                    mainButtonStyleXAML = mainButtonStyleXAML.Replace("{PressedForeground}", pressedForeground);
    
                    mainButtonStyleXAML = mainButtonStyleXAML.Replace("{DisabledBackground}", disabledBackground);
                    mainButtonStyleXAML = mainButtonStyleXAML.Replace("{DisabledBorderBrush}", disabledBorderBrush);
                    mainButtonStyleXAML = mainButtonStyleXAML.Replace("{DisabledForeground}", disabledForeground);
    
                    StringReader mainButtonStyleXAMLStringReader = new StringReader(mainButtonStyleXAML);
                    XmlReader mainButtonStyleXAMLXMLReader = XmlReader.Create(mainButtonStyleXAMLStringReader);
                    Style mainButtonStyle = (Style)XamlReader.Load(mainButtonStyleXAMLXMLReader);
    
                    toStyle.Style = mainButtonStyle;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error at 'SetButtonCornerRadiusAndTriggerStyling'" + Environment.NewLine + Environment.NewLine + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
