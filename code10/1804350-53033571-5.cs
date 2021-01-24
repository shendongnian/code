    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using QuantumWeb.Data;
    using QuantumWeb.Model;
    
    namespace QuantumWeb.Pages.Customers
    {
        public class CustomerProjectSkillAssignModel : PageModel
        {
            private readonly QuantumDbContext _context;
    
            public CustomerProjectSkillAssignModel(QuantumDbContext context)
            {
                _context = context;
            } // end public CustomerProjectSkillAssignModel(QuantumDbContext context)
    
    
            [BindProperty]
            public Project Project { get; set; }
            [BindProperty]
            public Customer Customer { get; set; }
    
            [BindProperty]
            public SkillTitle SkillTitle { get; set; }
    
            public async Task<IActionResult> OnGet(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                } // endif (id == null)
    
                Project = await _context.Projects
                    .Include(p => p.Customer)
                    .Include(p => p.ProjectSkills)
                        .ThenInclude(ps => ps.SkillTitle)
                        .FirstOrDefaultAsync(p => p.ProjectId == id);
    
                if (Project == null)
                {
                    return NotFound();
                } // endif (Project == null)
    
                Customer = Project.Customer;
    
                ViewData["SkillCode"] = new SelectList(_context.SkillTitles, "SkillCode", "Title");
    
                return Page();
            }// end public async Task<IActionResult> OnGet(int? id)
    
            public async Task<IActionResult> OnPostAsync()
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                } // endif (!ModelState.IsValid)
    
                ProjectSkill projectSkill = new ProjectSkill()
                {
                    ProjectId = Project.ProjectId,
                    SkillCode = SkillTitle.SkillCode
                };
    
                _context.ProjectSkills.Add(projectSkill);
                await _context.SaveChangesAsync();
    
                return RedirectToPage("./CustomerProjectSkills", new { id = Project.ProjectId });
            } // end public async Task<IActionResult> OnPostAsync()
    
        } // end public class CustomerProjectSkillAssignModel : PageModel
    
    } // end namespace QuantumWeb.Pages.Customers
