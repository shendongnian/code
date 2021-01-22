    using System;
    using System.Diagnostics;
    using System.Windows;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    
    namespace Console
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private void Window_Loaded(object sender, RoutedEventArgs e)
            {
                ProcessStartInfo cmdStartInfo = new ProcessStartInfo("cmd.exe");
                cmdStartInfo.CreateNoWindow = true;
                cmdStartInfo.RedirectStandardInput = true;
                cmdStartInfo.RedirectStandardOutput = true;
                cmdStartInfo.RedirectStandardError = true;
                cmdStartInfo.UseShellExecute = false;
                cmdStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
    
                _cmd = new Process();
                _cmd.StartInfo = cmdStartInfo;
    
                if (_cmd.Start() == true)
                {
                    _cmd.OutputDataReceived += new DataReceivedEventHandler(_cmd_OutputDataReceived);
                    _cmd.ErrorDataReceived += new DataReceivedEventHandler(_cmd_ErrorDataReceived);
                    _cmd.Exited += new EventHandler(_cmd_Exited);
    
                    _cmd.BeginOutputReadLine();
                    _cmd.BeginErrorReadLine();
                }
                else
                {
                    _cmd = null;
                }
            }
    
            private void Window_Closed(object sender, EventArgs e)
            {
                if ((_cmd != null) &&
                    (_cmd.HasExited != true))
                {
                    _cmd.CancelErrorRead();
                    _cmd.CancelOutputRead();
                    _cmd.Close();
                    _cmd.WaitForExit();
                }
            }
    
            void _cmd_OutputDataReceived(object sender, DataReceivedEventArgs e)
            {
                UpdateConsole(e.Data);
            }
    
            void _cmd_ErrorDataReceived(object sender, DataReceivedEventArgs e)
            {
                UpdateConsole(e.Data, Brushes.Red);
            }
    
            void _cmd_Exited(object sender, EventArgs e)
            {
                _cmd.OutputDataReceived -= new DataReceivedEventHandler(_cmd_OutputDataReceived);
                _cmd.Exited -= new EventHandler(_cmd_Exited);
            }
    
            private void ScrollViewer_SizeChanged(object sender, SizeChangedEventArgs e)
            {
                outputViewer.ScrollToBottom();
            }
    
            private void input_KeyDown(object sender, KeyEventArgs e)
            {
                switch (e.Key)
                {
                    case Key.Enter:
                        _cmd.StandardInput.WriteLine(input.Text);
                        input.Text = "";
                        break;
                    case Key.Escape:
                        input.Text = "";
                        break;
                }
            }
    
            private void UpdateConsole(string text)
            {
                UpdateConsole(text, null);
            }
    
            private void UpdateConsole(string text, Brush color)
            {
                if (!output.Dispatcher.CheckAccess())
                {
                    output.Dispatcher.Invoke(
                            new Action(
                                    () =>
                                    {
                                        WriteLine(text, color);
                                    }
                                )
                        );
                }
                else
                {
                    WriteLine(text, color);
                }
            }
    
            private void WriteLine(string text, Brush color)
            {
                if (text != null)
                {
                    Span line = new Span();
                    if (color != null)
                    {
                        line.Foreground = color;
                    }
                    foreach (string textLine in text.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
                    {
                        line.Inlines.Add(new Run(textLine));
                    }
                    line.Inlines.Add(new LineBreak());
                    output.Inlines.Add(line);
                }
            }
    
            Process _cmd;
        }
    }
