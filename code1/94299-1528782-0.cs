            List<int> list = new List<int> { 1, 2, 3 };
            StringBuilder sb = new StringBuilder();
            var y = list.Select((int x, int index) =>
                      sb.AppendFormat("{0}{1}",
                                       index > 0 ? "," : String.Empty,
                                       x)).ToList();
          
            Console.WriteLine(sb.ToString());
