        public class FileModel : PageModel
        {
            public void OnGet()
            {
            }
            [BindProperty]
            public IFormFile FormFile { get; set; }
            [IgnoreAntiforgeryToken]
            public async Task<IActionResult> OnPostUploadFileAsync()
            {
                
                return RedirectToPage("Index");
            }
            public async Task<IActionResult> OnGetDownloadAsync(string filename)
            {
                if (filename == null)
                    return Content("filename not present");
                var path = Path.Combine(
                            Directory.GetCurrentDirectory(),
                            "wwwroot", filename);
                var memory = new MemoryStream();
                using (var stream = new FileStream(path, FileMode.Open))
                {
                    await stream.CopyToAsync(memory);
                }
                memory.Position = 0;
                return File(memory, "application/octet-stream", Path.GetFileName(path));
            }
        }
