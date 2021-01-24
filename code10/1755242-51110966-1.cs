    var items = textBox16.Text
                         .Split(new[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries)
                         .ToList();
    var lines = File.ReadAllLines("watcher.txt");
    
    var missing = items.Where(item => !lines.Contains(item))
                         .ToList();
    if(missing.Any())
        MessageBox.Show($"Missing : \r\n {string.Join("\r\n", missing)}");
