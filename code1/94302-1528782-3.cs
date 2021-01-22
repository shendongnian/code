            List<int> list = new List<int> { 1, 2, 3 };
            StringBuilder sb = new StringBuilder();
            var y = list.Skip(1).Aggregate(sb.Append(x.ToString()),
                        (sb1, x) =>  sb1.AppendFormat(",{0}",x));
            // A lot of mess to remove initial comma
            Console.WriteLine(y.ToString().Substring(1,y.Length - 1));
