        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,BenchmarkScore,PicturePath,Price")] PcComponentItemVM componentVM)
        }
        {
