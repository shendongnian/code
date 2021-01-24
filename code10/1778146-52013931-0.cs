    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using temp.Data;
    
    public class MenuModel
    {
        public string MyProperty { get; set; }
        public string MyOtherProperty { get; set; }
    }
    
    public class MenuViewComponent : ViewComponent
    {
    
        private readonly ApplicationDbContext dbContext;
    
        public MenuViewComponent(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = dbContext...
                return View(model);
        }
    }
