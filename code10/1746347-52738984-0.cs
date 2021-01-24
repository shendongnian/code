         public class Article:Entity<Guid>
        {
            public string Title { get; set; }
            public string Brand { get; set; }
            public string DescriptionDutch { get; set; }
            public string DescriptionFrench { get; set; }
            public decimal Price { get; set; }
            public int Discount { get; set; }
        
            public ICollection<ArticleImage> ArticleImages { get; set; }
    
    //add constructor, and initilize the id        
    public Article(){
        this.Id = Guid.NewGuid();
        }
    
            public override bool Equals(object obj)
            {
                if (!(obj is Article article)) return false;
                return article.Title.Equals(Title)
                    && article.Id.Equals(Id)
                    && article.IsDeleted.Equals(IsDeleted)
                    && article.Brand.Equals(Brand)
                    && article.DescriptionDutch.Equals(DescriptionDutch)
                    && article.DescriptionFrench.Equals(DescriptionFrench)
                    && article.Price.Equals(Price)
                    && article.Discount.Equals(Discount)
                    && article.ArticleImages.SequenceEqual(ArticleImages);
            }
        }
