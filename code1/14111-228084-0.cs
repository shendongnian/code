public string Reverse(string str)
{
    char[] array = str.ToCharArray();
    Array.Reverse(array);
    return new string(array);
}
