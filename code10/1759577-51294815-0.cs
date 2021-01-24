    public async Task<IActionResult> Index() {
        var gifts = await _context.GiftCertificates
            .Include(e => e.VoucherCampaigns)
            .Include(e => e.CouponBrand)
            .Include(e => e.CouponTypes)
            .ToListAsync();
        return View(gifts);
    }
