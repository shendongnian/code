            var stringBuilder = new System.Text.StringBuilder();
            foreach (var item in results)
            {
                stringBuilder.Append($"{item.Word} occured {item.Count} times");
                stringBuilder.Append(Environment.NewLine);
            }
            MessageBox.Show(stringBuilder.ToString());
