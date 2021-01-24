    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    
    namespace WpfApp1
    {
        using System.Windows.Controls.Primitives;
    
        public partial class Window1 : Window
        {
            private ToolTip toolTip;
            public Window1()
            {
                InitializeComponent();
                toolTip = new ToolTip { Placement = PlacementMode.Relative, PlacementTarget = TextEditor};
                TextEditor.ToolTip = toolTip;
            }
    
            private void TextEditor_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.Key == Key.Space)
                {
                    var caret = this.TextEditor.TextArea.Caret.CalculateCaretRectangle();
                    toolTip.HorizontalOffset = caret.Right;
                    toolTip.VerticalOffset = caret.Bottom;
                    toolTip.Content = "aa";
                    toolTip.IsOpen = true;
                }
                else
                {
                    toolTip.IsOpen = false;
                }
            }
        }
    }
