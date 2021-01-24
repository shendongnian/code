 
        public async Task Use(string pointer, Func<System.IO.Stream, Task> useAction)
        {
            if (useAction == null)
            {
                throw new ArgumentNullException(nameof(useAction));
            }
            var blobRef = await utils.GetBlockBlobReference(storageFactory, pointer);
            using (var cloudStream = await blobRef.OpenWriteAsync())
            {
                await useAction(cloudStream);
            }
        }
