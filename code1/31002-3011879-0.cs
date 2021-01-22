    List<int> intList = new List<int>();
            //Use a ReadOnlyCollection around the List
            System.Collections.ObjectModel.ReadOnlyCollection<int> mValue = new System.Collections.ObjectModel.ReadOnlyCollection<int>(intList);
            for (int i = 0; i < 100000000; i++)
            {
                intList.Add(i);
            }
            long result = 0;
            //Use normal foreach on the ReadOnlyCollection
            TimeSpan lStart = new TimeSpan(System.DateTime.Now.Ticks);
            foreach (int i in mValue)
                result += i;
            TimeSpan lEnd = new TimeSpan(System.DateTime.Now.Ticks);
            MessageBox.Show("Speed(ms): " + (lEnd.TotalMilliseconds - lStart.TotalMilliseconds).ToString());
            MessageBox.Show("Result: " + result.ToString());
            //use <list>.ForEach
            lStart = new TimeSpan(System.DateTime.Now.Ticks);
            result = 0;
            intList.ForEach(delegate(int i) { result += i; });
            lEnd = new TimeSpan(System.DateTime.Now.Ticks);
            MessageBox.Show("Speed(ms): " + (lEnd.TotalMilliseconds - lStart.TotalMilliseconds).ToString());
            MessageBox.Show("Result: " + result.ToString());
