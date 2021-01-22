DateTime? d = DateTime.TryParse("some date text", out DateTime dt) ? dt : null;
If you want to make it a proper TryParse pseudo-extension method, you can do this:
public static bool TryParse(string text, out DateTime? dt)
{
    if (DateTime.TryParse(text, out DateTime date))
    {
        dt = date;
        return true;
    }
    else
    {
        dt = null;
        return false;
    }
}
