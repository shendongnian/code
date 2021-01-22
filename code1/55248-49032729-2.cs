    new Grid
        .AddColumns(
            new Column { Width = GridLength.Auto },
            new Column { Width = GridLength.Auto, MaxWidth = 20 },
            new Column { Width = GridLength.Star(1) },
            new Column { Width = GridLength.Auto }
        )
        .AddChildren(
            "Id",
            "Name",
            "Main Window Title",
            "Private Memory",
            processes.Select(process => new object[] {
                process.Id,
                process.ProcessName,
                process.MainWindowTitle,
                process.PrivateMemorySize64.ToString("n0"),
            })
        )
