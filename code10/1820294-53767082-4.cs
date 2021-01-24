             private void DG_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
             
            var scroll = MethodRepo.FindVisualChildren<ScrollViewer>((DependencyObject)sender);
            int firstRow = (int)scroll.First().VerticalOffset;
            int lastRow = (int)scroll.First().VerticalOffset + (int)scroll.First().ViewportHeight + 1;
           
            List<int> FirstColumnLength = new List<int>();
            List<int> SecondColumnLength = new List<int>();
            for (int i = firstRow; i < lastRow-1; i++)
            {
                FirstColumnLength.Add(Convert.ToString(persons[i].Name).Length);
                SecondColumnLength.Add(Convert.ToString(persons[i].Surname).Length);
            }
            DG.Columns[0].Width = FirstColumnLength.Max()*10;
            DG.Columns[1].Width = SecondColumnLength.Max() * 10;
        }
