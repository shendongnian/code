        int characterLimit = charaterlimit;
        string output = input;
        // Check if the string is longer than the allowed amount
        // otherwise do nothing
        if (output.Length > characterLimit && characterLimit > 0)
        {
            // cut the string down to the maximum number of characters
            output = output.Substring(0, characterLimit);
            // Check if the character right after the truncate point was a space
            // if not, we are in the middle of a word and need to remove the rest of it
            if (input.Substring(output.Length, 1) != " ")
            {
                int LastSpace = output.LastIndexOf(" ");
                // if we found a space then, cut back to that space
                if (LastSpace != -1)
                {
                    output = output.Substring(0, LastSpace);
                }
            }
            // Finally, add the "..."
            output += "...";
        }
        return output;
    }
