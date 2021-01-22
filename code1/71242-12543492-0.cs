    public string GenRandString(int length)
    {
      byte[] randBuffer = new byte[length];
      RandomNumberGenerator.Create().GetBytes(randBuffer);
      return System.Convert.ToBase64String(randBuffer).Remove(length);
    }
