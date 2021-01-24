    using System.Linq;
    string GetUri(SyndicationFeed image)
    {
        return image.Links.Where(link => link != null && link.Contains("image")).FirstOrDefault() ?? "";
    }
