void Main()
{
  DoStuff(PrintString);
}
void PrintString(string text)
{
  Console.WriteLine(text);
}
void DoStuff(OneArgumentDelegate action) 
{
  action("Hello!");
}
This will output Hello!.
Lambda expressions are a shorthand for the DoStuff(PrintString) so you don't have to create a method for every delegate variable you're going to use. You 'create' a temporary method that's passed on to the method. It works like this:
DoStuff(string text => Console.WriteLine(text)); // single line
DoStuff(string text => // multi line
{
  Console.WriteLine(text);
  Console.WriteLine(text);
});
