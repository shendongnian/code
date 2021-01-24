    public class CreateModel : PageModel {
        private readonly IItemService _itemService;
    
        public CreateModel(IItemService itemService) {
            _itemService = itemService;
        }
        [BindProperty]
        public ItemCreateViewModel ItemModel { get; set; }
        // all related data downloaded from db, so all rendered correctly
        public  async Task<IActionResult>  OnGetAsync() {
            ItemModel = await _itemService.GetCreateViewModel();
            return Page();
        }
    
        public async Task<IActionResult> OnPostAsync() {
            if (!ModelState.IsValid) {
                return Page();
            }
            var item = _itemService.CreateItem(ItemModel);
            var image = await ImagesController.ProcessFormImage(ItemModel.ImageUpload.UploadPhoto, item.Id, ModelState);
            if (!ModelState.IsValid) {                
                return Page();
            }
            await _itemService.SaveItemImage(image);
            _itemService.CreateItem(ItemModel);
            return RedirectToPage("./Index");
        }
    }
