    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.EntityFrameworkCore;
    using QuantumWeb.Data;
    using QuantumWeb.Model;
    
    namespace QuantumWeb.Pages.Customers
    {
        public class EditModel : PageModel
        {
            private readonly QuantumDbContext _context;
    
            public EditModel(QuantumDbContext context)
            {
                _context = context;
            } // end public EditModel(QuantumDbContext context)
    
            [BindProperty]
            public Customer Customer { get; set; }
    
            public async Task<IActionResult> OnGetAsync(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                } // endif (id == null)
    
                Customer =
                    await _context.Customers
                        .FirstOrDefaultAsync(m => m.CustomerId == id);
    
                if (Customer == null)
                {
                    return NotFound();
                } // endif (Customer == null)
                return Page();
            } // end public async Task<IActionResult> OnGetAsync(int? id)
    
            public async Task<IActionResult> OnPostAsync()
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                } // endif (!ModelState.IsValid)
    
                _context.Attach(Customer).State = EntityState.Modified;
    
                try
                {
                    await _context.SaveChangesAsync();
                } // end try
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(Customer.CustomerId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    } // endif (!CustomerExists(Customer.CustomerId))
                } // end catch (DbUpdateConcurrencyException)
    
                return RedirectToPage("./Index");
            } // end public async Task<IActionResult> OnPostAsync()
    
            private bool CustomerExists(int id)
            {
                return _context.Customers.Any(e => e.CustomerId == id);
            } // end private bool CustomerExists(int id)
    
        } // end public class EditModel : PageModel
    
    } // end namespace QuantumWeb.Pages.Customers
