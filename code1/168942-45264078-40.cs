    public class ContactInfo 
    {
       // constructor 
       public TResult Match<TResult>(
                          Func<EmailAddress,TResult> f1,
                          Func<PostalAddress,TResult> f2,
                          Func<Tuple<EmailAddress,PostalAddress>> f3
                      )
       {
            if (_emailAddress != null) 
            {
                 return f1(_emailAddress);
            } 
            else if(_postalAddress != null)
            {
                 ...
            } 
            ...
       }
    }
