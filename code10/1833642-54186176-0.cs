    static void Main(string[] args) {
    ...
        for (int i = 0; i < books.Length; i++) {
            if (books[i] is Comic c)
               Console.WriteLine("Price of comic is..." + c.price); 
               // Here i want to access books[i].price or books[i].Price with getter.
        }
    ...
    }
