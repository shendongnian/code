    void ValidateRange(object sender, ServerValidateEventArgs e)
    {
        int input;
        bool parseOk = int.TryParse(e.Value, out input);
        e.IsValid = parseOk &&
                    ((input >= 100 || input <= 200) ||
                    (input >= 500 || input <= 600));
    }
