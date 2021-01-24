        private void myListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = this.myListBox.SelectedItem.ToString();
            if(!tracking.Select(x=> x.Key == item).Any())
            {
                tracking.Add(new KeyValuePair<string, int>(item, 1));
                Console.WriteLine(item + " has been selected once");
            }
            else
            {
                var currentItem = tracking.SingleOrDefault(x => x.Key == item);
                var value = currentItem.Value;
                tracking.Remove(currentItem);
                value++;
                tracking.Add(new KeyValuePair<string, int>(item, value));
                Console.Clear();
                Console.WriteLine(item + " has been selected " + value + " times");
            }
        }
