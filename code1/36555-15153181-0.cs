    public static void EncodeQueryString(ref string queryString)
    {
        var array=queryString.Split('&','=');
        for (int i = 0; i < array.Length; i++) {
            string part=array[i];
            if(i%2==1)
            {               
                part=System.Web.HttpUtility.UrlEncode(array[i]);
                queryString=queryString.Replace(array[i],part);
            }
        }
    }
