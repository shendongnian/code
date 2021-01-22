    // This method tries to handle:
    // (1) Combining characters
    // These are two or more Unicode characters that are combined into one glyph.
    // For example, try reversing "Not nai\u0308ve.". The diaresis (¨) should stay over the i, not move to the v.
    // (2) Surrogate pairs
    // These are Unicode characters whose code points exceed U+FFFF (so are not in "plane 0").
    // To be represented with 16-bit 'char' values (which are really UTF-16 code units), one character needs *two* char values, a so-called surrogate pair.
    // For example, try "The sphere \U0001D54A and the torus \U0001D54B.". The  and the  should be preserved, not corrupted.
    var value = "reverse me"; // or "Not nai\u0308ve.", or "The sphere \U0001D54A and the torus \U0001D54B.". 
    var list = new List<string>(value.Length);
    var enumerator = StringInfo.GetTextElementEnumerator(value);
    while (enumerator.MoveNext())
    {
      list.Add(enumerator.GetTextElement());
    }
    list.Reverse();
    var result = string.Concat(list);
