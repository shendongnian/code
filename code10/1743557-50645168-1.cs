    [HttpDelete("{id}")]
            public async Task<IActionResult> Delete (string id)
            {
                return (await _repo.Delete(ObjectId.Parse(id)))
                 ? (IActionResult) Ok("Deleted Successfully")
                 : NotFound();
            }
