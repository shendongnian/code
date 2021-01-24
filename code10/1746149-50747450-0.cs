    var col = mydb.GetCollection<Library>("Libraries");
    var filter = Builders<Library>.Filter.Not(
        Builders<Library>.Filter.ElemMatch(x => x.Author.Books, b => b.IsVerified == false));
    var update = Builders<Library>.Update.Set(l => l.AllBooks, true);
    await col.UpdateManyAsync(filter, update);
 
