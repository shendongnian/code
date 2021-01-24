    string s = "2 << 1";
    string operator_ = (new string(s.Where(c => !char.IsDigit(c)).ToArray())).Trim();
    int operand1 = Convert.ToInt32(s.Substring(0, s.IndexOf(operator_)).Trim());
    int operand2 = Convert.ToInt32(s.Substring(s.IndexOf(operator_) + operator_.Length).Trim());
                
    int result = 0;
    switch (operator_)
    {
        case "<<":
             result = operand1 << operand2;
             break;
        case ">>":
             result = operand1 >> operand2;
             break;
    }
    Console.WriteLine(string.Format("{0} {1} {2} = {3}", operand1, operator_, operand2, result));
