            string[] arr1 = new string[] { "The ", "A " };
            string Origional = Text.ToLower();
            if (Text.Length > 4)
            {
                foreach (string match in arr1)
                {
                    if (Origional.StartsWith(match.ToLower()))
                    {
                        //Origional = Origional.Replace(match.ToLower(), "").TrimStart();
                        Origional = Origional.Replace(Origional.Substring(0, match.Length), "").TrimStart();
                        return Origional;
                    }
                }
            }
            return Origional;
        }
