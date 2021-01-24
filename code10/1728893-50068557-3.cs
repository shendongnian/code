    account.DoubleAmount = 100000;
    account.FormatNumbers();
    Console.Write(account.Amount); // "100k" = ok
    account.DoubleAmount = 0;
    Console.Write(account.Amount); // "100k" = inconsistent = very bad
