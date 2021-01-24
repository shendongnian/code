        List<ListBoxArticle> check = new List<ListBoxArticle>();
    
        private void SelectArt_Checked(object sender, RoutedEventArgs e)
        {
            //Remplissage des Elements Sélectionnés
            check.AddRange(LesArticles.Where(x => x.IsChecked == true && !check.Contains(x)));
            LesElem = new ObservableCollection<ListBoxArticle>(check);
    
            OnPropertyChanged("LesElem"); // <-- something like this
        }
