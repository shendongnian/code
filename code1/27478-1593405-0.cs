    public class BookViewModel
    {
       private Author _filterAuthorBy;
       
       public BookViewModel(IBookView view)
       {
          ...
          _books = new CollectionViewSource();
          _books.Source = _bookRepository.FindAll().ToArray();
          _books.Filter += (sender, e) =>
                             {
                                 Book book = e.Item as Book;
                                 if (_filterAuthorBy == null)
                                 {
                                     e.Accepted = true;
                                 }
                                 else
                                 {
                                     e.Accepted = book.Authors.Contains(_filterAuthorBy);
                                 }
                             };
       }
       public CollectionView Books
       {
           get
           {               
               return _books.View;
           }
       }
       
       public ObservableCollection<Author> Authors
       {
          get
          {
             return new ObservableCollection<Author>(_bookRepository.FindAllAuthors());
          }
       }
       public Author FilterAuthorBy
       {
           get
           {
               return _filterAuthorBy;
           }
           set
           {
               _filterAuthorBy = value;
               _books.View.Refresh();
           }
        } 
    }
