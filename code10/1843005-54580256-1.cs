    [HttpPost("")]
    public async Task<ActionResult<TProductResource>> Create(TProductDTO dto)
    {
        var product = _mapper.Map<TProduct>(dto);
        _context.Add(product);
        await _context.SaveChangesAsync();
        return CreatedAt("Get", new { product.Id }, _mapper.Map<TProductDTO>(product));
    }
