    using Microsoft.Extensions.Caching.Memory;
    using Microsoft.Extensions.Options;
    UnityContainer container = new UnityContainer(); // your unity container
    MemoryCacheOptions memoryCacheOptions = new MemoryCacheOptions
    {
        //config your cache here
    };
    
    MemoryCache memoryCache = new MemoryCache(Options.Create<MemoryCacheOptions>(memoryCacheOptions));
    container.RegisterInstance<IMemoryCache>(memoryCache);
