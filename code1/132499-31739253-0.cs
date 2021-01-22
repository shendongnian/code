    private void BotaoParaTestes_Click(object sender, EventArgs e)
    {
        string linha = @"clonehd " +
            "\"Z:\\Máquinas Virtuais\\Teste.vdi\" " +
            "\"C:\\Temp\\teste.vdi\" " +
            "--format VDI --variant Standard";
 
        Thread tarefa = new Thread(Executar);
        tarefa.Start(linha);
    }
    private void Executar(object Linha)
    {
        FixedProcess fp = new FixedProcess ();
        fp.StartInfo.FileName = ItensEstaticos.VBox;
        fp.StartInfo.Arguments = Linha.ToString();
        fp.StartInfo.CreateNoWindow = true;
        fp.StartInfo.ErrorDialog = false;
        fp.StartInfo.RedirectStandardError = true;
        fp.StartInfo.RedirectStandardOutput = true;
        fp.StartInfo.UseShellExecute = false;
        fp.ErrorDataReceived += (sendingProcess, errorLine) => Escrita(errorLine.Data);
        fp.OutputDataReceived += (sendingProcess, dataLine) => Escrita(dataLine.Data);
        fp.Start();
        fp.BeginErrorReadLine();
        fp.BeginOutputReadLine();
        fp.WaitForExit();
    }
    private void Escrita(string Texto)
    {
        if (!string.IsNullOrEmpty(Texto))
        {
            BeginInvoke(new MethodInvoker(delegate
            {
                this.Texto.Text += Texto;
            }));
        }
    }
