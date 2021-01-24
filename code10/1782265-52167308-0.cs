    using Windows.UI;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Input;
    using Windows.UI.Xaml.Media;
    
    namespace App1
    {
        public static class UIHelper
        {
            public static void CreateRemovableTextBoxToCanvas(Canvas canvas, string label = null)
            {
                canvas.IsHitTestVisible = true;
    
                InputScope scope = new InputScope();
    
                InputScopeName scopeName = new InputScopeName
                {
                    NameValue = InputScopeNameValue.ChatWithoutEmoji
                };
    
                scope.Names.Add(scopeName);
    
                int controlIndex = canvas.Children.Count - 1;
    
                if (label == null)
                {
                    label = "Field " + canvas.Children.Count;
                }
    
                TextBlock newTextBlock = new TextBlock
                {
                    Text = label,
                    VerticalAlignment = VerticalAlignment.Center,
                    TextAlignment = TextAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    Margin = new Thickness(0, 0, 10, 0)
                };
    
                TextBox newTextBox = new TextBox
                {
                    Name = "TextBox" + controlIndex,
                    Foreground = new SolidColorBrush(Colors.Black),
                    Background = new SolidColorBrush(Colors.Transparent),
                    BorderBrush = new SolidColorBrush(Colors.DarkGray),
                    CanDrag = true,
                    IsTapEnabled = true,
                    PlaceholderText = "Type Text Here...",
                    FontSize = 14f,
                    AcceptsReturn = true,
    
                    // Win Onscreen Keyboard Settings
                    AllowFocusOnInteraction = true,
                    PreventKeyboardDisplayOnProgrammaticFocus = false,
                    InputScope = scope,
    
                    ManipulationMode = ManipulationModes.All,
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Width = 130
                };
    
                Button deleteTextBoxButton = new Button
                {
                    Name = "DeleteTextBoxButton" + controlIndex,
                    Content = new StackPanel
                    {
                        Children =
                        {
                            new SymbolIcon
                            {
                                Symbol = Symbol.Delete
                            },
                        }
                    },
                    Visibility = Visibility.Collapsed
                };
    
                StackPanel newTextStackPanel = new StackPanel
                {
                    Orientation = Orientation.Horizontal,
                    Children = { newTextBlock, newTextBox, deleteTextBoxButton }
                };
    
                newTextBox.LostFocus += (s, args) => deleteTextBoxButton.Visibility = Visibility.Collapsed;
                newTextBox.GotFocus += (s, args) => deleteTextBoxButton.Visibility = Visibility.Visible;
    
                int topOffset = 40 * canvas.Children.Count;
    
                if (canvas.Children.Count > 0)
                {
                    Canvas.SetLeft(newTextStackPanel, 0);
                    Canvas.SetTop(newTextStackPanel, topOffset);
                }
    
                canvas.Children.Add(newTextStackPanel);
            }
        }
    }
