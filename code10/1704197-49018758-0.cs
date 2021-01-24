    ... some validation logic outside the scope of the question...
    using (HttpClient client = new HttpClient())
        			{
        				var file = await client.GetAsync($"{someURL}/{id}");
        				return new FileContentResult(await file.Content.ReadAsByteArrayAsync(), file.Content.Headers.ContentType.MediaType);
        			}
