    var list = new List<Article>
    {
        new Article(){
            Title = "Article 1", Date = new DateTime(2018,1,1),
            Reviews = new List<Review> {
                new Review(){Points=10}, new Review(){Points=10},
            },
        },
        new Article(){
            Title = "Article 2", Date = new DateTime(2018,1,2),
            Reviews = new List<Review> {
                new Review(){Points=10}, new Review(){Points=9}, new Review(){Points=8},
            },
        },
        new Article(){
            Title = "Article 3", Date = new DateTime(2018,1,3),
            Reviews = new List<Review> {
                new Review(){Points=9},
            },
        },
    };
