    [Area("admin")]
    [Route("[area]/invoice-categories/[action]"]
    class InvoiceCategoriesController {
        public IActionResult New() {}
        public IActionResult Edit(int id) {}
        [Route("[area]/invoice-categories"]
        public IActionResult Index() {}
    }
