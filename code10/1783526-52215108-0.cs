    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var product = await _context.Product.SingleOrDefaultAsync(m => m.Id == id);
        var stuff = await _context.ProductDescription.FirstOrDefaultAsync(c => c.Product.Id == id);
        _context.Product.Remove(product);
        _context.ProductDescription.Remove(stuff);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
       builder.Entity<Product>()
            .HasMany(s => s.ProductDescription)
            .WithOne(c = c.Product)
            .OnDelete(DeleteBehavior.Cascade);
