      using System.Linq;
      ...
      string raw = "Fox jumps over the rope (1):AB 123";
      // "Fox jumps over the rope "
      string cleared = string.Concat(raw
        .TakeWhile(c => char.IsLetter(c) || char.IsWhiteSpace(c)));
