    static void Main(string[] args) {
    ...
        for (int i = 0; i < books.Length; i++) {
            if (books[i] is Comic)
               Comic c = books[i] as Comic;
               Console.WriteLine("Price of comic is..." + c.Price); 
        }
    ...
    }
