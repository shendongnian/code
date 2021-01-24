    private async void GridView_AddBook(Book book)
    {
        await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
        {
            ViewModel.Books.Add(book);
        });
    }
