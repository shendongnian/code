      List1.ForEach(x =>
            {
                var item = List2.FirstOrDefault(y => y.RowNo == x.RowNo);
                if (item != null)
                {
                    x.Value = item.Value;
                }
            });
