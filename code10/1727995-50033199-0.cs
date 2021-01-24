    public class IndexModel : PageModel
        {
            public void OnGet()
            {
                Task<int> task = HandleMessagesAsync();
            }
    
            private async Task<int> HandleMessagesAsync()
            {
                var query = ParseObject.GetQuery("Message");
                IEnumerable<ParseObject> results = await query.FindAsync();
                var count = await query.CountAsync();
    
                Debug.WriteLine("# Message: " + count);
    
                throw new NotImplementedException();
            }
        }
