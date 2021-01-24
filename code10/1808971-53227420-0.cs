    public ActionResult Index()
    {
        List<Books> books = db.Books.ToList()
        List<ChapterList> chapterList = (from a in db.Books
                                        join b in db.Charpters on a.id equals b.BookId
                                        //where a.id==3 you can also query for specific book
                                        select new ChapterList
                                        {
                                         chapter=b.chapter
                                        }).ToList();
                                      
        BookViewModel bvm = new BookViewModel();
        bvm.books = books;
        bvm.chapterLists = chapterLists
        return view();
    }
