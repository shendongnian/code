    int iRows = ft.CurrentTB.LineInfos.Count;
        for (int i = 1; i <= iRows; i++)
        {
            CurrentTB[i].BackgroundBrush = Brushes.Transparent;         
            CurrentTB.DoSelectionVisible();
       }
                CurrentTB.Select();
                CurrentTB.DoSelectionVisible();
