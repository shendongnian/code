    [Route("{dir}/{subdir}/filename")]
    public async Task<IActionResult> Get(string dir, string subdir, string filename)
    {
      string path = dir + "/" + subdir + "/" + filename;
      //path e.g. is somedir/somesubdir/filename.extension
      string prefix = "https://example-domain.com/api/v1/Other/";
      //string path2 = HttpContext.Request.Path.Value.Replace("/api/v1/Test/", "/api/v1/Other/").Replace("%2F", "/");
      return Redirect(prefix + path);
    }
