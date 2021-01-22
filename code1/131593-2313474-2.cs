static String GetUsername(String value)
{
    String result = "";
    String token = "Username=";
    
    int index = value.IndexOf(token) + token.Length;
    while (value[index] != ';')
    {
        result += value[index++];
        if (index > value.Length - 1)
            break;
    }
    return result;
}
