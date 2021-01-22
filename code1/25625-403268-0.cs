public static void Withdrawal(Account account, decimal amount)
{
    DB.UpdateBalance(account.AccountNumber, amount);
}
public static void Withdraw(int accountNumber, decimal amount)
{
    DB.UpdateBalance(accountNumber, amount);
}
