    using System;
    using System.IO;
    using System.Threading.Tasks;  
    using System.Windows.Forms;
    namespace TextArrayManipulation
    { 
        public partial class Form1 : Form
        {
            private TaskCompletionSource<string> _translationSubmittedSource = new TaskCompletionSource<string>();
            private string[,] _result;
            public Form1()
            {
                InitializeComponent();
            }
            private async void buttonOpen_Click(object sender, EventArgs e)
            {
                using (var ofd = new OpenFileDialog())
                {
                    if (ofd.ShowDialog() != DialogResult.OK) return;
                    _result = new string[GetTotalLineCount(ofd.FileName), 4];
                    using (var streamReader = new StreamReader(ofd.FileName))
                    {
                        var line = string.Empty;
                        var lineCount = 0;
                        while (line != null)
                        {
                            line = streamReader.ReadLine();
                           
                            if (string.IsNullOrWhiteSpace(line)) continue;
                        
                            // update GUI
                            textBoxLine.Text = line;
                            labelLineNumber.Text = lineCount.ToString();
                        
                            // wait for user to enter a translation
                            var translation = await _translationSubmittedSource.Task;
                            // split line at tabstop
                            var parts = line.Split('\t');
                            // populate result
                            _result[lineCount, 0] = lineCount.ToString();
                            _result[lineCount, 1] = parts[0];
                            _result[lineCount, 2] = parts[1];
                            _result[lineCount, 3] = translation;
                            // reset soruce
                            _translationSubmittedSource = new TaskCompletionSource<string>();
                            // clear TextBox
                            textBoxTranslation.Clear();
                            // increase line count
                            lineCount++;
                        }
                    }
                    // proceede as you wish...
                }
            }
            private static int GetTotalLineCount(string filePath)
            {
                using (StreamReader r = new StreamReader(filePath))
                {
                    int i = 0;
                    while (r.ReadLine() != null) { i++; }
                    return i;
                }
            }
            private void buttonSubmit_Click(object sender, EventArgs e)
            {
                _translationSubmittedSource.TrySetResult(textBoxTranslation.Text);
            }
        }
    }
    
