// Put all your shared methods in generic classes in here.
public static class MyMethods
{
    public static T Method<T extends MyClass>(this T x)
    {
        ...
    }
}
Your classes don't change much, except they won't need to mention `Method` (or the other shared methods) at all.
abstract class MyClass
{
    ...
}
class MyClass1 : MyClass
{
    ...
}
class MyClass2 : MyClass
{
    ...
}
