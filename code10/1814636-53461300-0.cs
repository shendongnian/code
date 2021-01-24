            // string: employeeid  first int: total score   second int: number of questions
            Dictionary<string, Tuple<int, int>> results = new Dictionary<string, Tuple<int, int>>();
            foreach (ListViewItem item in lstvwSource.Items)
            {
                if (results.ContainsKey(item.Text))
                {
                    results[item.Text] = new Tuple<int, int>(Convert.ToInt32(item.SubItems[1].Text) + results[item.Text].Item1, +results[item.Text].Item2 + 1);
                }
                else
                {
                    Tuple<int, int> tuple = new Tuple<int, int>(Convert.ToInt32(item.SubItems[1].Text), 1);
                    results.Add(item.Text, tuple);
                }
            }
            //
            lstvwDest.Items.Clear();
            foreach (var result in results)
            {
                ListViewItem newItem = new ListViewItem();
                newItem.Text = result.Key;
                newItem.SubItems.Add(result.Value.Item1.ToString());
                double avg = (double)result.Value.Item1 / (double)result.Value.Item2;
                newItem.SubItems.Add(avg.ToString());
                lstvwDest.Items.Add(newItem);
            }
