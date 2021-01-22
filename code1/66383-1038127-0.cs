    public interface IBook
    {
        string ISBN {get;}
    }
    public class BookWrapper   //Or whatever you want to call it :)
    {
        //Create a new book in the constructor
        public BookWrapper()
        {
            BookData = new Data.MyORM.CreateNewBook();
        }
        //Expose the IBook, so we dont have to cascade the ISBN calls to it
        public IBook BookData {get; protected set;}
        //Also add whichever business logic operation we need here
        public Author LookUpAuther()
        {
           if (IBook == null)
              throw new SystemException("Noes, this bookwrapper doesn't have an IBook :(")
           //Contact some webservice to find the author of the book, based on the ISBN
        }
    }
