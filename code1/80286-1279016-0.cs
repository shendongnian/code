    public static List<string> GetVideosAttribute( Func<Video,string> selector )
    {
        var Videos = QueryVideos(HttpContext.Current);
        return Videos.Where(v => v.Type == "exampleType"
                     .SelectMany( selector )
                     .Distinct()
                     .OrderBy(s => s)
                     .ToList();
    }
    var speakers = GetVideosAttribute( v => v->SpeakerName );
    var topics = GetVideosAttribute( v => v->Topic );
