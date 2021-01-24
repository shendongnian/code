      var splittet = input.Select(i => i.Split("\\".ToCharArray(),  StringSplitOptions.RemoveEmptyEntries));
      Action<string[], int> print = (string[] lst, int index) => Console.WriteLine("\\" + string.Join("\\", lst.Skip(index)));
      splittet.Aggregate(new string[] { },
        (common, item) =>
        {
          var index = Enumerable.Range(0, Math.Min(common.Length, item.Length)).FirstOrDefault(i => common[i] != item[i]);
          print(item, index);
          return item;
        }
        );
