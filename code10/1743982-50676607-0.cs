        private void ButtonClick2(object sender, EventArgs e)
        {
            var api = new GingerItApi();
            Console.Write("Text to check: ");
            var text = Label.Text;
            if (!string.IsNullOrEmpty(text))
            {
                try
                {
                    var result = api.Check(text);
                    if (result?.Corrections?.Count != 0)
                    {
                        for (int i = 0; i < result.Corrections.Count; i++)
                        {
                            var item = result.Corrections[i];
                            var mistakes = string.Join(", ", item.Mistakes.Select(x => $"\"{text.Substring(x.From, x.To - x.From + 1)}\""));
                            var suggestions = string.Join(", ", item.Suggestions.Select(x => $"\"{x.Text}\""));
                            Label1.Text = $"  {i + 1}: {mistakes} >> {suggestions}";
                        }
                    }
                    else
                    {
                        Label1.Text = "Looks okay.\n";
                        Console.WriteLine("Looks okay.\n");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"**Error: {ex.Message}\n");
                }
            }
        }
