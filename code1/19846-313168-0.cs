    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }
        private void inspect(object sender, RoutedEventArgs e)
        {
            TextPointer pointer = FindRun(inBox.Document);
            string textAfterBreak = FindBreak(pointer);
            outBox.Text = textAfterBreak;
        }
        private string FindBreak(TextPointer pointer)
        {
            Rect rectAtStart = pointer.GetCharacterRect(LogicalDirection.Forward);
            pointer = pointer.GetNextInsertionPosition(LogicalDirection.Forward);
            Rect currentRect = pointer.GetCharacterRect(LogicalDirection.Forward);
            while (currentRect.Bottom == rectAtStart.Bottom)
            {
                pointer = pointer.GetNextInsertionPosition(LogicalDirection.Forward);
                currentRect = pointer.GetCharacterRect(LogicalDirection.Forward);
            }
            string textBeforeBreak = pointer.GetTextInRun(LogicalDirection.Backward);
            string textAfterBreak = pointer.GetTextInRun(LogicalDirection.Forward);
            return textAfterBreak;
        }
        private TextPointer FindRun(FlowDocument document)
        {
            TextPointer position = document.ContentStart;
            while (position != null)
            {
                if (position.Parent is Run)
                    break;
                position = position.GetNextContextPosition(LogicalDirection.Forward);
            }
            return position;
        }
    }
    <Window x:Class="LineBreaker.Window1"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        Title="Window1" Height="300" Width="300">
        <Grid>
            <Grid.RowDefinitions>
                <RowDefinition></RowDefinition>
                <RowDefinition></RowDefinition>
                <RowDefinition></RowDefinition>
            </Grid.RowDefinitions>
            <RichTextBox Grid.Row="0" Name="inBox">
            </RichTextBox>
            <Button Grid.Row="1" Click="inspect">Find Break</Button>
            <TextBox Name="outBox" Grid.Row="2"/>
        </Grid>
    </Window>
