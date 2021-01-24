Console.Write("Enter Mass1 ");
int Mass1 = int.Parse(Console.ReadLine());
// Console.ReadLine() method returns the `string` 
// hence you need to parse it to specific type before assigning it
Console.Write("Enter Lil Numbers ");
int LilNum = int.Parse(Console.ReadLine());
// same here
Console.Write("Enter Mass2 ");
int Mass2 = int.Parse(Console.ReadLine());
// same here
Console.Write("Enter Lil Numbers ");
int LilNum2 = int.Parse(Console.ReadLine());
// same here
Console.Write("Enter Distance between Mass1 & 2 ");
int distance = int.Parse(Console.ReadLine());
// You are using `Mass` which is not present
// `Mass1` was `string` type on which you can not do division
int Mass3 = Mass1 / Mass2;
hope this helps.
