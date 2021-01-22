    Must(Names.Length == URLs.Length).WithMessage("Names must be equal in size to URLs");
    for (int i = 0; i < Name.Length; i++)
    {
        Must(string.IsNullOrEmpty(Names[i]) ^^ string.IsNullOrEmpty(URLs[i])).WithMessage("Either Name and URL must be non-empty, or both must be empty, index = " + i);
    }
