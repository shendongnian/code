            // string: employeeid - first int: total score - second int: number of questions
            Dictionary<string, Tuple<int, int>> results = new Dictionary<string, Tuple<int, int>>();
            foreach (ListViewItem item in lstvwSource.Items)
            {
                // check if employeeid is in Dictionary
                if (results.ContainsKey(item.Text))
                {
                    // if employeeid exists in dictionary
                    // add currnet score to total score
                    // and add one to number of questions
                    results[item.Text] = new Tuple<int, int>(Convert.ToInt32(item.SubItems[1].Text) + results[item.Text].Item1, +results[item.Text].Item2 + 1);
                }
                else
                {
                    // if employeeid does not exist in dictionary
                    // add employeeid , score of the question
                    // set number of questions to 1
                    Tuple<int, int> tuple = new Tuple<int, int>(Convert.ToInt32(item.SubItems[1].Text), 1);
                    results.Add(item.Text, tuple);
                }
            }
            // 
            lstvwDest.Items.Clear();
            foreach (var result in results)
            {
                ListViewItem newItem = new ListViewItem();
                newItem.Text = result.Key; // employeeid
                newItem.SubItems.Add(result.Value.Item1.ToString()); // total score
                double avg = (double)result.Value.Item1 / (double)result.Value.Item2;
                newItem.SubItems.Add(avg.ToString()); // average score
                lstvwDest.Items.Add(newItem);
            }
