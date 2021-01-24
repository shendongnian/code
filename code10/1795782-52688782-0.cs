    public bool CheckValidation(string input)
        {
            input = input.Trim();
            if (input == string.Empty) return false;
            var mRegxExpression = new Regex("^([0-2][0-9]|(3)[0-1])(((0)[0-9])|((1)[0-2]))\\d{2}(\\-)\\d{5}$");
            return mRegxExpression.IsMatch(input);
        }
