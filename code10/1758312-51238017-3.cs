     public static string GetNearestKnownColor(string hex)
     {
         hex = hex.TrimStart('#');
         if (hex.Length != 6) throw new Exception();
         var color = System.Drawing.ColorTranslator.FromHtml("#" + hex);
         double bestSquared = double.MaxValue;
         KnownColor bestMatch = default(KnownColor);
         foreach (KnownColor ce in typeof(KnownColor).GetEnumValues())
         {
             Color tryColor = Color.FromKnownColor(ce);
             double deltaR = tryColor.R - color.R;
             double deltaG = tryColor.G - color.G;
             double deltaB = tryColor.B - color.B;
             double squared = deltaR * deltaR + deltaG * deltaG + deltaB * deltaB;
             if (squared < bestSquared)
             {
                 bestMatch = ce;
                 bestSquared = squared;
             }
         }
         return bestMatch.ToString();
     }
