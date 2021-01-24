    var queryResult = initialQuery
        // Transfer only the data you actually plan to use to your process
        .Select(joinResult => new
        { 
             AuthorName = joinResult.AuthorName,
             BookName = joinResult.BookTitle,
        })
        // move the selected data to local process in efficient way
        .AsEnumerable()
        // now you are free to use your local constructor:
        .Select(fetchedData => new BookViewModel()
        {
             BookName = fetchedData.BookName,
             AuthorName = fetchedData.AuthorName,
        });
