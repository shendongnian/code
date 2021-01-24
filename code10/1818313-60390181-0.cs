@page
@functions
{
    public IActionResult OnGet()
    {
        return Redirect("https://www.google.com");
    }
}
Or if it's an internal page simply:
@page
@functions
{
    public IActionResult OnGet()
    {
        return RedirectToPage("/SomePage", new { area = "SomeArea" });
    }
}
Notice that in both scenarios the `Redirect/RedirectToPage` are being returned as an `IActionResult`.
Hope this helps
