    public class DownloadModel : PageModel
    {
        public IActionResult OnGet(string name) {
            // do your magic here
            var content = new byte[] { 1, 2, 3 };
            return File(content, "application/octet-stream", name);
        }
    }
