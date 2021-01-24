    private bool ValidateMime(string mimeType)
            {
                if(mimeArray.Any(x => x.IsMatch(mimeType)))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
