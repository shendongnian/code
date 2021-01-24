    const string base36 = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    static void GetRandomBytes (byte[] buffer)
    {
    	using (var random = RandomNumberGenerator.Create ())
    		random.GetBytes (buffer);
    }
    
    /// <summary>
    /// Generates a Message-Id.
    /// </summary>
    /// <remarks>
    /// Generates a new Message-Id using the supplied domain.
    /// </remarks>
    /// <returns>The message identifier.</returns>
    /// <param name="domain">A domain to use.</param>
    /// <exception cref="System.ArgumentNullException">
    /// <paramref name="domain"/> is <c>null</c>.
    /// </exception>
    /// <exception cref="System.ArgumentException">
    /// <paramref name="domain"/> is invalid.
    /// </exception>
    public static string GenerateMessageId (string domain)
    {
    	if (domain == null)
    		throw new ArgumentNullException (nameof (domain));
    
    	if (domain.Length == 0)
    		throw new ArgumentException ("The domain is invalid.", nameof (domain));
    
    	ulong value = (ulong) DateTime.Now.Ticks;
    	var id = new StringBuilder ();
    	var block = new byte[8];
    
    	GetRandomBytes (block);
    
    	do {
    		id.Append (base36[(int) (value % 36)]);
    		value /= 36;
    	} while (value != 0);
    
    	id.Append ('.');
    
    	value = 0;
    	for (int i = 0; i < 8; i++)
    		value = (value << 8) | (ulong) block[i];
    
    	do {
    		id.Append (base36[(int) (value % 36)]);
    		value /= 36;
    	} while (value != 0);
    
    	id.Append ('@').Append (domain);
    
    	return id.ToString ();
    }
