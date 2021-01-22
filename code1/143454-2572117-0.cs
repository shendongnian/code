    int NthIndexOf(string s, char t, int n) {
       if(n < 0) { throw new ArgumentException(); }
       if(n==1) { return s.IndexOf(t); }
       if(t=="") { return 0; }
       string et = RegEx.Escape(t);
       string pat = "(?<="
          + Microsoft.VisualBasic.StrDup(n-1, et + @"[.\n]*") + ")"
          + et;
       Match m = RegEx.Match(s, pat);
       return m.Success ? m.Index : -1;
    }
