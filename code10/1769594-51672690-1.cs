            string x = "@#=";
            string z = "1234";
            string w = "1234@";
            bool b = Array.TrueForAll(x.ToCharArray(), y => (Char.IsSymbol(y) || Char.IsPunctuation(y))); // true
            bool c = Array.TrueForAll(z.ToCharArray(), y => (Char.IsSymbol(y) || Char.IsPunctuation(y))); // false
            bool e = Array.TrueForAll(w.ToCharArray(), y => (Char.IsSymbol(y) || Char.IsPunctuation(y))); // false
