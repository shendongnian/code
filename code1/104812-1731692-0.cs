string txt = Console.ReadLine();
if (!int.TryParse(txt))
{
  // not a number, handle it
}
else
{
  // we can convert this as we know it's a number
  int number = Convert.ToInt32(txt);
}
