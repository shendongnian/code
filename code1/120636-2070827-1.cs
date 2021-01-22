public bool Contains(string value)
{
    return (this.IndexOf(value, StringComparison.Ordinal) >= 0);
}
 
