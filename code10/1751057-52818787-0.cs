    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using JW;
    namespace RazorPagesPagination.Pages
    {
        public class IndexModel : PageModel
        {
            public IEnumerable<string> Items { get; set; }
            public Pager Pager { get; set; }
            public void OnGet(int p = 1)
            {
                // generate list of sample items to be paged
                var dummyItems = Enumerable.Range(1, 150).Select(x => "Item " + x);
                // get pagination info for the current page
                Pager = new Pager(dummyItems.Count(), p);
                // assign the current page of items to the Items property
                Items = dummyItems.Skip((Pager.CurrentPage - 1) * Pager.PageSize).Take(Pager.PageSize);
            }
        }
    }
