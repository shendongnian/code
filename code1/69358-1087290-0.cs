        if (txtBox1.Text.Length >= 4 && txtBox1.Text.ToCharArray().Take(4).All(c => char.IsLetter(c)))
        {
            // success
        }
        else
        {
            // validation failed
        }
