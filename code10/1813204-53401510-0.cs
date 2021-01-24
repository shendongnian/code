    string dirConta = $"{Environment.CurrentDirectory}/Bd/contas.txt";
    private Task ModifyFileAsync()
    {
        var output = new List<string>();
        foreach (var line in File.ReadLines(dirConta))
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
        WriteAllText(dirConta, string.Join("\n", lines));
        return Task.CompletedTask;
    }
    private async void buttonGravaPass_Click(object sender, EventArgs e)
    {
        await ModifyFileAsync().ConfigureAwait(false);
    }
