    public static bool IsValidCustom(this string value)
    {
        string regExPattern="^([\-\.a-zA-Z ÇüéâäàåçêëèïîíìÄÅÉæÆôöòûùÖÜáíóúñÑÀÁÂÃÈÊËÌÍÎÏÐÒÓÔÕØÙÚÛÝßãðõøýþÿ]+)$";
        return Rege1x.IsMatch(input, regExPattern);
    }
