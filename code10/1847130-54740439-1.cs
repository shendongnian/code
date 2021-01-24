        private IEnumerable<string> GetSlices() =>
            Enumerable
                .Range(0, 3)
                .SelectMany(n => new[]
                {
                    String.Join("", Enumerable.Range(0, 3).Select(m => _buttons[m][n].Text)),
                    String.Join("", Enumerable.Range(0, 3).Select(m => _buttons[n][m].Text))
                })
                .Concat(new[]
                {
                    String.Join("", Enumerable.Range(0, 3).Select(x => _buttons[x][x].Text)),
                    String.Join("", Enumerable.Range(0, 3).Select(x => _buttons[x][2 - x].Text))
                });
