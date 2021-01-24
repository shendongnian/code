    public IEnumerable<T> FilterMyList<T>(IEnumerable<T> list, string fieldval1, string fieldval2, string deger)
    {
        foreach (var element in list)
        {
        	var nesteValue1 = element.GetType().GetProperty(fieldval1).GetValue(element);
        	var	nestedValue2 = nesteValue1.GetType().GetProperty(fieldval2).GetValue(nesteValue1);
        	if (nestedValue2.ToString().ToLower() == deger)
        	{
        		yield return element;
        	}
        }
    }
