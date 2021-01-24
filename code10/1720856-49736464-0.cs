    public class HeaderViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await GetModelAsync();
            return View(model);
        }
        public Task<HeaderModel> GetModelAsync()
            => return Task.FromResult(new HeaderModel());
    }
