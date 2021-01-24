       private async void AsTaskBtn_Click(object sender, EventArgs e)
       {
           var strings = await GetStringsAsync();
           var result = string.Join(" ", strings);
           MessageBox.Show(result);
       }
       private async Task<IEnumerable<string>> GetStringsAsync()
       {
           return await Task.Run<IEnumerable<string>>(
               () => {
                   var listOfStrings = new List<string>();
                   var strings = new[] { "Some", "strings", "go", "here" };
                   foreach (var s in strings)
                   {
                       listOfStrings.Add(s);
                       Thread.Sleep(500);
                   }
                   return listOfStrings;
               });
       }
