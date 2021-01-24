    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [SwaggerWcf("/v1/rest")]
    public class BookStore : IStore
    {
    
        [SwaggerWcfTag("Books")]
        [SwaggerWcfResponse(HttpStatusCode.OK, "Book found, value in the response body")]
        [SwaggerWcfResponse(HttpStatusCode.NoContent, "No books", true)]
        public Book[] ReadBooks(string filterText = null)
        {
            WebOperationContext woc = WebOperationContext.Current;
            if (woc == null)
                return null;
            if (Store.Books.Any())
            {
                woc.OutgoingResponse.StatusCode = HttpStatusCode.OK;
                return string.IsNullOrEmpty(filterText)
                    ? Store.Books.ToArray()
                    : Store.Books.Where(b => b.Author.Name.Contains(filterText) || b.Title.Contains(filterText)).ToArray();
            }
            woc.OutgoingResponse.StatusCode = HttpStatusCode.OK;
            return Store.Books.ToArray();
        }
    }
