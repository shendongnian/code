    public void removeVowels()
    {
           string str = "MultilanguAge File07";
           var chr = str.Where(c => !"aeiouAEIOU0-9 ".Contains(c)).ToList();
           Console.WriteLine(string.Join("", chr));
    }
