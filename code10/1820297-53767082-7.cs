         ScrollViewer scroll = null;
        private void DG_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            // get the control once and then use its offset to get the row index
            if (scroll == null)
                scroll = MethodRepo.FindVisualChildren<ScrollViewer>((DependencyObject)sender).First(); 
            int firstRow = (int)scroll.VerticalOffset;
            int lastRow = (int)scroll.VerticalOffset + (int)scroll.ViewportHeight + 1;
           
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
