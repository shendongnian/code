      [Serializable]
            public class Book
            {
                [XmlAttribute]
                public string author;
                public int quantity;
                public int price;
                [XmlIgnore]
                public int total;
                //public NameValueCollection nvcollection = new NameValueCollection();
                public Book() { }
                public Book(string author, int quantity, int price)
                {
                    this.author = author;
                    this.quantity = quantity;
                    this.price = price;
                    total = quantity * price;
                    //nvcollection.Add(author, price.ToString());
                }
            }
