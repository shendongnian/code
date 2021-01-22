    using System;
    using System.Drawing;
    using System.Diagnostics;
    using System.Windows.Forms;
    
    class Test
    {
        [STAThread]
        static void Main(string[] args)
        {
            Button button = new Button {
                Text = "Click me",
                Dock = DockStyle.Top
            };        
            TextBox textBox = new TextBox {
                Multiline = true,
                ReadOnly = true,
                Location = new Point(5, 50),
                Dock = DockStyle.Fill
            };
            Form form = new Form {
                Text = "Pinger",
                Size = new Size(500, 300),
                Controls = { textBox, button }
            };
            
            Action<string> appendLine = line => {
                MethodInvoker invoker = () => textBox.AppendText(line + "\r\n");
                textBox.BeginInvoke(invoker);
            };
            
            button.Click += delegate
            {        
                ProcessStartInfo psi = new ProcessStartInfo("ping")
                {
                    UseShellExecute = false,
                    RedirectStandardError = true,
                    RedirectStandardOutput = true,
                    Arguments = "google.com"
                };
                Process proc = Process.Start(psi);
                proc.EnableRaisingEvents = true;
                proc.OutputDataReceived += (s, e) => appendLine(e.Data);
                proc.BeginOutputReadLine();
                proc.ErrorDataReceived += (s, e) => appendLine(e.Data);
                proc.BeginErrorReadLine();
                proc.Exited += delegate { appendLine("Done"); };
            };
            
            Application.Run(form);
        }
    }
