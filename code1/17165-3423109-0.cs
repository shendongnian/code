    /// <summary>
    /// Returns a string representation of a byte array.
    /// </summary>
    /// <param name="bytearray">The byte array to represent.</param>
    /// <param name="subdivision">The number of elements per group,
    /// or 0 to not restrict it. The default is 0.</param>
    /// <param name="subsubdivision">The number of elements per line,
    /// or 0 to not restrict it. The default is 0.</param>
    /// <param name="divider">The string dividing the individual bytes. The default is " ".</param>
    /// <param name="subdivider">The string dividing the groups. The default is "  ".</param>
    /// <param name="subsubdivider">The string dividing the lines. The default is "\r\n".</param>
    /// <param name="uppercase">Whether the representation is in uppercase hexadecimal.
    /// The default is <see langword="true"/>.</param>
    /// <param name="prebyte">The string to put before each byte. The default is an empty string.</param>
    /// <param name="postbyte">The string to put after each byte. The default is an empty string.</param>
    /// <returns>The string representation.</returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="bytearray"/> is <see langword="null"/>.
    /// </exception>
    public static string ToArrayString(this byte[] bytearray,
    	int subdivision = 0,
    	int subsubdivision = 0,
    	string divider = " ",
    	string subdivider = "  ",
    	string subsubdivider = "\r\n",
    	bool uppercase = true,
    	string prebyte = "",
    	string postbyte = "")
    {
    	#region Contract
    	if (bytearray == null)
    		throw new ArgumentNullException("bytearray");
    	#endregion
    
    	StringBuilder sb = new StringBuilder(
    		bytearray.Length * (2 + divider.Length + prebyte.Length + postbyte.Length) +
    		(subdivision > 0 ? (bytearray.Length / subdivision) * subdivider.Length : 0) +
    		(subsubdivision > 0 ? (bytearray.Length / subsubdivision) * subsubdivider.Length : 0));
    	int groupElements = (subdivision > 0 ? subdivision - 1 : -1);
    	int lineElements = (subsubdivision > 0 ? subsubdivision - 1 : -1);
    	for (long i = 0; i < bytearray.LongLength - 1; i++)
    	{
    		sb.Append(prebyte);
    		sb.Append(String.Format(CultureInfo.InvariantCulture, (uppercase ? "{0:X2}" : "{0:x2}"), bytearray[i]));
    		sb.Append(postbyte);
    
    		if (lineElements == 0)
    		{
    			sb.Append(subsubdivider);
    			groupElements = subdivision;
    			lineElements = subsubdivision;
    		}
    		else if (groupElements == 0)
    		{
    			sb.Append(subdivider);
    			groupElements = subdivision;
    		}
    		else
    			sb.Append(divider);
    
    		lineElements--;
    		groupElements--;
    	}
    	sb.Append(prebyte);
    	sb.Append(String.Format(CultureInfo.InvariantCulture, (uppercase ? "{0:X2}" : "{0:x2}"), bytearray[bytearray.LongLength - 1]));
    	sb.Append(postbyte);
    
    	return sb.ToString();
    }
