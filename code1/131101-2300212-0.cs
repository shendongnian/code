string one = "(999) 999-9999";
string two = "2221239876";
StringBuilder result = new StringBuilder();
int indexInTwo = 0;
for (int i = 0; i &lt; one.Length; i++)
{
    char character = one[i];
    if (char.IsDigit(character))
    {
        if (indexInTwo &lt; two.Length)
        {
            result.Append(two[indexInTwo]);
            indexInTwo++;
        }
        else
        {
            // ran out of characters in two
            // use default character or throw exception?
        }
    }
    else
    {
        result.Append(character);
    }
}
