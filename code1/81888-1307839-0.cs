    static readonly Regex r = new Regex(
      @"^(['\-\.a-zA-Z ÇüéâäàåçêëèïîíìÄÅÉæÆôöòûùÖÜáíóúñÑ"+
       "ÀÁÂÃÈÊËÌÍÎÏÐÒÓÔÕØÙÚÛÝßãðõøýþÿ]+)$");
    public bool IsValidCustom(string value)
    {
      return r.IsMatch(value);
    }
