    public static bool IsValidCustom(this string value)
    {
        string regExPattern="^([\-\.a-zA-Z ÇüéâäàåçêëèïîíìÄÅÉæÆôöòûùÖÜáíóúñÑÀÁÂÃÈÊËÌÍÎÏÐÒÓÔÕØÙÚÛÝßãðõøýþÿ]+)$";
        return Regex.IsMatch(input, regExPattern);
    }
