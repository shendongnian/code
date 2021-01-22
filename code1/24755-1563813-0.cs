    Public Sub KillCache()
        Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache)
        Response.Cache.SetExpires(New Date(1900, 1, 1))
        Response.Cache.SetMaxAge(New TimeSpan(0, 0, 5))   '// 5 SECONDS'
        Response.Cache.SetNoServerCaching()
        Response.Cache.SetNoStore()
        Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches)
    End Sub
