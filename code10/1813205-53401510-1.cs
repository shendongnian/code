    string dirConta = $"{Environment.CurrentDirectory}/Bd/contas.txt";
    private async Task ModifyFileAsync()
    {
        var output = new List<string>();
        using (var reader = new StreamReader(dirConta))
        {
            while ((var line = await reader.ReadLineAsync().ConfigureAwait(false)) != null)
            {
                var parts = line.Split('|');
                if (parts[0] == Users.user)
                {
                    var newLine = line.Replace(parts[1], "12345");
                    lines.Add(newLine);
                }
                else
                {
                    lines.Add(line);
                }
            }
        }
        using (var writer = new StreamWriter(dirConta))
        {
            foreach (var line in lines)
            {
                await writer.WriteLineAsync(line).ConfigureAwait(false);
            }
        }
    }
    private async void buttonGravaPass_Click(object sender, EventArgs e)
    {
        await ModifyFileAsync().ConfigureAwait(false);
    }
