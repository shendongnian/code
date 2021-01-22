    public static string StrReverse(this string expression)
    {
        if ((expression == null))
            return "";
        int srcIndex;
        var length = expression.Length;
        if (length == 0)
            return "";
        //CONSIDER: Get System.String to add a surrogate aware Reverse method
        //Detect if there are any graphemes that need special handling
        for (srcIndex = 0; srcIndex <= length - 1; srcIndex++)
        {
            var ch = expression[srcIndex];
            var uc = char.GetUnicodeCategory(ch);
            if (uc == UnicodeCategory.Surrogate || uc == UnicodeCategory.NonSpacingMark || uc == UnicodeCategory.SpacingCombiningMark || uc == UnicodeCategory.EnclosingMark)
            {
                //Need to use special handling
                return InternalStrReverse(expression, srcIndex, length);
            }
        }
        var chars = expression.ToCharArray();
        Array.Reverse(chars);
        return new string(chars);
    }
    ///<remarks>This routine handles reversing Strings containing graphemes
    /// GRAPHEME: a text element that is displayed as a single character</remarks>
    private static string InternalStrReverse(string expression, int srcIndex, int length)
    {
        //This code can only be hit one time
        var sb = new StringBuilder(length) { Length = length };
        var textEnum = StringInfo.GetTextElementEnumerator(expression, srcIndex);
        //Init enumerator position
        if (!textEnum.MoveNext())
        {
            return "";
        }
        var lastSrcIndex = 0;
        var destIndex = length - 1;
        //Copy up the first surrogate found
        while (lastSrcIndex < srcIndex)
        {
            sb[destIndex] = expression[lastSrcIndex];
            destIndex -= 1;
            lastSrcIndex += 1;
        }
        //Now iterate through the text elements and copy them to the reversed string
        var nextSrcIndex = textEnum.ElementIndex;
        while (destIndex >= 0)
        {
            srcIndex = nextSrcIndex;
            //Move to next element
            nextSrcIndex = (textEnum.MoveNext()) ? textEnum.ElementIndex : length;
            lastSrcIndex = nextSrcIndex - 1;
            while (lastSrcIndex >= srcIndex)
            {
                sb[destIndex] = expression[lastSrcIndex];
                destIndex -= 1;
                lastSrcIndex -= 1;
            }
        }
        return sb.ToString();
    }
