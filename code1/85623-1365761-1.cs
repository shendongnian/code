    public class AuthorEquals : IEqualityComparer<Author>
    {
        public bool Equals(Author left, Author right)
        {
            if((object)left == null && (object)right == null)
            {
                return true;
            }
            if((object)left == null || (object)right == null)
            {
                return false;
            }
            return left.FirstName == right.FirstName && left.LastName == right.LastName;
        }
    
        public int GetHashCode(Author author)
        {
            return (author.FirstName + author.LastName).GetHashCode();
        }
    }
