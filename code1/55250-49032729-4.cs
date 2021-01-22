    new Grid { Stroke = StrokeHeader, StrokeColor = DarkGray }
        .AddColumns(
            new Column { Width = GridLength.Auto },
            new Column { Width = GridLength.Auto, MaxWidth = 20 },
            new Column { Width = GridLength.Star(1) },
            new Column { Width = GridLength.Auto }
        )
        .AddChildren(
            new Cell { Stroke = StrokeHeader, Color = White }
                .AddChildren("Id"),
            new Cell { Stroke = StrokeHeader, Color = White }
                .AddChildren("Name"),
            new Cell { Stroke = StrokeHeader, Color = White }
                .AddChildren("Main Window Title"),
            new Cell { Stroke = StrokeHeader, Color = White }
                .AddChildren("Private Memory"),
            processes.Select(process => new[] {
                new Cell { Stroke = StrokeRight }
                    .AddChildren(process.Id),
                new Cell { Stroke = StrokeRight, Color = Yellow, TextWrap = TextWrapping.NoWrap }
                    .AddChildren(process.ProcessName),
                new Cell { Stroke = StrokeRight, Color = White, TextWrap = TextWrapping.NoWrap }
                    .AddChildren(process.MainWindowTitle),
                new Cell { Stroke = LineThickness.None, Align = HorizontalAlignment.Right }
                    .AddChildren(process.PrivateMemorySize64.ToString("n0")),
            })
        )
