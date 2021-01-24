    // Inside the event handler for check and uncheck
    BookViewModel bookViewModel = this.DataContext as BookViewModel;
    // When some checkbox is checked
    if (bookViewModel != null){
        this.booksViewModel.SelectedChapters.Add(selectedChapter);
    }
    
    // When some checkbox is unchecked
    if (bookViewModel != null){
        this.booksViewModel.SelectedChapters.Remove(selectedChapter);
    }
