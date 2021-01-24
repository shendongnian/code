    public partial class Tsia : Form
    {
        [...]
    
        private async Task TypeText()
        {
            await WritingAnimator("Some text");
            await WritingAnimator("This is another text");
        }
    
        private async Task WritingAnimator(string text)
        {
            foreach (char c in text)
            {
                TextBox1.AppendText(c.ToString());
                await Task.Delay(100);
            }
        }
    }
