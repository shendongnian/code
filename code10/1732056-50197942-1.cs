        [HttpPost]
        [Route("ad/story-location/attach")]
        public async Task<HttpResponseMessage>Reattach([FromQuery]long storyid,[FromBody]StoryLocation[] data)
        {
            try
            {
                var delRecords = from record in this._context.StoryLocation
                          where record.StoryId == data[0].StoryId
                          select record;
                this._context.RemoveRange(delRecords);
                foreach(var item in delRecords)
                {
                     if (!item .IsNull()) // I'm using a extension method
                     {
                         // detach
                         _context.Entry(item ).State = EntityState.Detached;
                     }
                }
                await this._context.StoryLocation.AddRangeAsync(data);
                int rowsAffected=await this._context.SaveChangesAsync();
                return new HttpResponseMessage
                {
                    StatusCode = System.Net.HttpStatusCode.OK,
                    Content = new StringContent($"Rows affected:{rowsAffected.ToString()}")
                };
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage
                {
                    StatusCode = System.Net.HttpStatusCode.NoContent,
                    Content = ex.ToHttpContent()
                };
            }
        }
