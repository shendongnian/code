        [AspNetCompatibilityRequirements(RequirementsMode =   AspNetCompatibilityRequirementsMode.Allowed)]
       [SwaggerWcf("Store.svc")]
    public class BookStore : IStore
    {
           [SwaggerWcfTag("Books")]
        [SwaggerWcfResponse(HttpStatusCode.OK, "Book found, value in the response body")]
       [SwaggerWcfResponse(HttpStatusCode.NoContent, "No books", true)]
        public Book[] ReadBooks(string filtername=null)
        {
            WebOperationContext woc = WebOperationContext.Current;
            if (woc == null)
                return null;
            if (Store.Books.Any())
            {
                woc.OutgoingResponse.StatusCode = HttpStatusCode.OK;
                return string.IsNullOrEmpty(filtername)
                    ? Store.Books.ToArray()
                    : Store.Books.Where(b => b.Author.Name.Contains(filtername) || b.Title.Contains(filtername)).ToArray();
            }
            woc.OutgoingResponse.StatusCode = HttpStatusCode.OK;
            return Store.Books.ToArray();
        }
    }
