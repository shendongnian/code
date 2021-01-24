    private string rating {
         get { return this.rating; }
            set
            {
                if (value == "PG" || value == "PG-13" || value == "R")
                {
                    rating = value;
                }
                else
                {
                    throw new UnknownRatingException();
                }
            }
    }
    public Book(string title, string author, string rating)
        {
            this.title = title;
            this.author = author;
            this.rating = rating //the set property is called
        }
