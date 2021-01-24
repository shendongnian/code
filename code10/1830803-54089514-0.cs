            string myBlobName = "valueGotFromOtherBinding";
            var attributes = new Attribute[]
            {
                new BlobAttribute($"outbound/{myBlobName}", FileAccess.Write),
                new StorageAccountAttribute(Settings.InbundBlobConnectionString)
            };
            using (var writer = await binder.BindAsync<TextWriter>(attributes))
            {
                await writer.WriteAsync("Conetent");
            }
