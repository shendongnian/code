csharp
Parent[] parentArray = new Parent[9];
for (int i = 0; i < 3; i++)
{
    parentArray[i] = new Parent();
}
for (int i = 3; i < 6; i++)
{
    parentArray[i] = new Child1();
}
for (int i = 6; i < 9; i++)
{
    parentArray[i] = new Child2();
}
