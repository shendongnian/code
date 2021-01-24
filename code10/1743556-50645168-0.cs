    public async Task<bool> Delete(ObjectId id)
            {
                var filter = Builders<ShortUrl>.Filter.Eq(x => x.Id, id);
                var r = await _db.Urls.DeleteOneAsync(filter);
                return r.DeletedCount > 0;
            }
